using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BE;
using Backup;

namespace MPP
{
    public class MPPMesa
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPMesa()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CrearXMLSiNoExiste()
        {
            if (!File.Exists(_ruta))
            {
                var docNuevo = new XDocument(
                    new XElement("Root",
                        new XElement("Mesas")
                    )
                );
                docNuevo.Save(_ruta);
            }

            _doc = XDocument.Load(_ruta);

            if (_doc.Root.Element("Mesas") == null)
            {
                _doc.Root.Add(new XElement("Mesas"));
                _doc.Save(_ruta);
            }
        }

        private long ObtenerUltimoId()
        {
            CrearXMLSiNoExiste();
            var mesas = _doc.Root.Element("Mesas").Elements("Mesa");
            if (!mesas.Any())
                return 0;

            return mesas.Max(x => (long)x.Attribute("Id"));
        }

        public long Guardar(BEMesa o)
        {
            CrearXMLSiNoExiste();

            if (o.Id == 0)
            {
                o.Id = ObtenerUltimoId() + 1;

                if (string.IsNullOrWhiteSpace(o.Codigo))
                    o.Codigo = "M" + o.Id.ToString("00");
                if (o.Numero == 0)
                    o.Numero = (int)o.Id;

                var xMesa = new XElement("Mesa",
                    new XAttribute("Id", o.Id),
                    new XElement("Codigo", o.Codigo ?? ""),
                    new XElement("Numero", o.Numero),
                    new XElement("Sector", o.Sector ?? ""),
                    new XElement("Capacidad", o.Capacidad),
                    new XElement("Estado", (int)o.Estado),
                    new XElement("Observaciones", o.Observaciones ?? "")
                );

                _doc.Root.Element("Mesas").Add(xMesa);
            }
            else
            {
                var xMesa = _doc.Root.Element("Mesas").Elements("Mesa")
                    .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

                if (xMesa == null)
                    throw new Exception("No se encontró la mesa para modificar.");

                xMesa.Element("Codigo").Value = o.Codigo ?? "";
                xMesa.Element("Numero").Value = o.Numero.ToString();
                xMesa.Element("Sector").Value = o.Sector ?? "";
                xMesa.Element("Capacidad").Value = o.Capacidad.ToString();
                xMesa.Element("Estado").Value = ((int)o.Estado).ToString();
                xMesa.Element("Observaciones").Value = o.Observaciones ?? "";
            }

            _doc.Save(_ruta);
            return o.Id;
        }

        public List<BEMesa> ListarTodo()
        {
            CrearXMLSiNoExiste();

            return _doc.Root.Element("Mesas").Elements("Mesa")
                .Select(x => new BEMesa
                {
                    Id = (long)x.Attribute("Id"),
                    Codigo = (string)x.Element("Codigo"),
                    Numero = (int)x.Element("Numero"),
                    Sector = (string)x.Element("Sector"),
                    Capacidad = (int)x.Element("Capacidad"),
                    Estado = (EstadoMesa)int.Parse(x.Element("Estado").Value),
                    Observaciones = (string)x.Element("Observaciones")
                })
                .OrderBy(m => m.Numero)
                .ToList();
        }

        public bool Eliminar(BEMesa o)
        {
            CrearXMLSiNoExiste();
            var xMesa = _doc.Root.Element("Mesas").Elements("Mesa")
                .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

            if (xMesa == null) return false;

            xMesa.Remove();
            _doc.Save(_ruta);
            return true;
        }
    }
}
