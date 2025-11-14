using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BE;
using Backup;  

namespace MPP
{
    public class MPPCobroMozo
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPCobroMozo()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void AsegurarXml()
        {
            if (!File.Exists(_ruta))
                throw new Exception("No se encontró el archivo BD.Xml");

            _doc = XDocument.Load(_ruta);

            if (_doc.Root.Element("CobrosMozo") == null)
            {
                _doc.Root.Add(new XElement("CobrosMozo"));
                _doc.Save(_ruta);
            }
        }

        public long ObtenerUltimoId()
        {
            AsegurarXml();
            var ids = _doc.Root.Element("CobrosMozo")
                        .Elements("CobroMozo")
                        .Select(x => (long)x.Attribute("Id"))
                        .ToList();

            return ids.Any() ? ids.Max() : 0;
        }

        public void Registrar(BECobroMozo cobro)
        {
            AsegurarXml();
            long nuevoId = ObtenerUltimoId() + 1;

            var nodo = new XElement("CobroMozo",
                new XAttribute("Id", nuevoId),
                new XElement("Id_Comanda", cobro.Id_Comanda),
                new XElement("FechaHora", cobro.FechaHora.ToString("s")),
                new XElement("Mozo", cobro.Mozo ?? ""),
                new XElement("Medio", cobro.Medio ?? ""),
                new XElement("Importe", cobro.Importe),
                new XElement("Rendido", cobro.Rendido)
            );

            _doc.Root.Element("CobrosMozo").Add(nodo);
            _doc.Save(_ruta);
        }

        public List<BECobroMozo> ListarNoRendidos()
        {
            AsegurarXml();

            var lista = _doc.Root.Element("CobrosMozo")
                .Elements("CobroMozo")
                .Where(x => (bool)x.Element("Rendido") == false)
                .Select(x => new BECobroMozo
                {
                    Id = (long)x.Attribute("Id"),
                    Id_Comanda = (long)x.Element("Id_Comanda"),
                    FechaHora = DateTime.Parse(x.Element("FechaHora").Value),
                    Mozo = (string)x.Element("Mozo"),
                    Medio = (string)x.Element("Medio"),
                    Importe = (decimal)x.Element("Importe"),
                    Rendido = (bool)x.Element("Rendido")
                })
                .ToList();

            return lista;
        }


        public void MarcarComoRendido(long idCobro)
        {
            AsegurarXml();
            var nodo = _doc.Root.Element("CobrosMozo")
                .Elements("CobroMozo")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idCobro);

            if (nodo == null)
                throw new Exception("No se encontró el cobro.");

            nodo.Element("Rendido").Value = "true";
            _doc.Save(_ruta);
        }
        public List<BECobroMozo> ListarPorFecha(DateTime fecha)
        {
            AsegurarXml();

            return _doc.Root.Element("CobrosMozo")
               .Elements("CobroMozo")
               .Where(x => DateTime.Parse(x.Element("FechaHora").Value).Date == fecha.Date)
               .Select(x => new BECobroMozo
               {
                   Id = (long)x.Attribute("Id"),
                   Id_Comanda = (long)x.Element("Id_Comanda"),
                   FechaHora = DateTime.Parse(x.Element("FechaHora").Value),
                   Mozo = (string)x.Element("Mozo"),
                   Medio = (string)x.Element("Medio"),
                   Importe = (decimal)x.Element("Importe"),
                   Rendido = (bool)x.Element("Rendido")
               })
               .ToList();
        }

    }
}
