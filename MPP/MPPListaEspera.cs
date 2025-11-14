using Abstraccion;
using Backup;
using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace MPP
{
    public class MPPListaEspera : IGestor<BEListaEspera>
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPListaEspera()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CrearXMLSiNoExiste()
        {
            if (!File.Exists(_ruta))
            {
                _doc = new XDocument(
                    new XElement("Root",
                        new XElement("ListasEspera")
                    )
                );
                _doc.Save(_ruta);
            }
            else
            {
                _doc = XDocument.Load(_ruta);

                if (_doc.Root.Element("ListasEspera") == null)
                {
                    _doc.Root.Add(new XElement("ListasEspera"));
                    _doc.Save(_ruta);
                }
            }
        }

        public bool CrearXML()
        {
            CrearXMLSiNoExiste();
            return true;
        }

        public bool Guardar(BEListaEspera o)
        {
            CrearXMLSiNoExiste();

            if (o.Id == 0)
            {
                o.Id = ObtenerUltimoId() + 1;

                if (o.Posicion == 0)
                    o.Posicion = CalcularSiguientePosicion();

                var xLE = new XElement("ListaEspera",
                    new XAttribute("Id", o.Id),
                    new XElement("FechaHoraIngreso", o.FechaHoraIngreso.ToString("o")),
                    new XElement("NombreCliente", o.NombreCliente ?? string.Empty),
                    new XElement("CantidadPersonas", o.CantidadPersonas),
                    new XElement("Contacto", o.Contacto ?? string.Empty),
                    new XElement("ETA", o.ETA.HasValue ? o.ETA.Value.ToString("o") : string.Empty),
                    new XElement("Estado", (int)o.Estado),
                    new XElement("Observaciones", o.Observaciones ?? string.Empty),
                    new XElement("Posicion", o.Posicion)
                );

                _doc.Root.Element("ListasEspera").Add(xLE);
            }
            else
            {
                var xLE = _doc.Root.Element("ListasEspera").Elements("ListaEspera")
                    .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

                if (xLE == null)
                    throw new Exception("No se encontró el registro de lista de espera para modificar.");

                xLE.Element("FechaHoraIngreso").Value = o.FechaHoraIngreso.ToString("o", CultureInfo.InvariantCulture);
                xLE.Element("NombreCliente").Value = o.NombreCliente ?? string.Empty;
                xLE.Element("CantidadPersonas").Value = o.CantidadPersonas.ToString();
                xLE.Element("Contacto").Value = o.Contacto ?? string.Empty;
                xLE.Element("ETA").Value = o.ETA.HasValue ? o.ETA.Value.ToString("o", CultureInfo.InvariantCulture) : string.Empty;
                xLE.Element("Estado").Value = ((int)o.Estado).ToString();
                xLE.Element("Observaciones").Value = o.Observaciones ?? string.Empty;
                xLE.Element("Posicion").Value = o.Posicion.ToString();
            }

            _doc.Save(_ruta);
            return true;
        }

        public bool Eliminar(BEListaEspera o)
        {
            CrearXMLSiNoExiste();
            var xLE = _doc.Root.Element("ListasEspera").Elements("ListaEspera")
                .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

            if (xLE != null)
            {
                xLE.Remove();
                _doc.Save(_ruta);
            }
            return true;
        }

        public List<BEListaEspera> ListarTodo()
        {
            CrearXMLSiNoExiste();

            return _doc.Root.Element("ListasEspera")
                .Elements("ListaEspera")
                .Select(x =>
                {
                    DateTime fhIngreso;
                    var fhStr = (string)x.Element("FechaHoraIngreso") ?? DateTime.Now.ToString("o");
                    if (!DateTime.TryParse(fhStr, null, DateTimeStyles.RoundtripKind, out fhIngreso))
                    {
                        DateTime.TryParse(fhStr, new CultureInfo("es-AR"), DateTimeStyles.None, out fhIngreso);
                    }

                    DateTime? eta = null;
                    var etaStr = (string)x.Element("ETA");
                    if (!string.IsNullOrWhiteSpace(etaStr))
                    {
                        if (DateTime.TryParse(etaStr, null, DateTimeStyles.RoundtripKind, out var etaTmp))
                            eta = etaTmp;
                        else if (DateTime.TryParse(etaStr, new CultureInfo("es-AR"), DateTimeStyles.None, out etaTmp))
                            eta = etaTmp;
                    }

                    int estadoInt = 0;
                    var elEstado = x.Element("Estado");
                    if (elEstado != null)
                        int.TryParse(elEstado.Value, out estadoInt);

                    return new BEListaEspera
                    {
                        Id = (long)x.Attribute("Id"),
                        FechaHoraIngreso = fhIngreso,
                        NombreCliente = (string)x.Element("NombreCliente"),
                        CantidadPersonas = (int)x.Element("CantidadPersonas"),
                        Contacto = (string)x.Element("Contacto"),
                        ETA = eta,
                        Estado = (EstadoListaEspera)estadoInt,
                        Observaciones = (string)x.Element("Observaciones"),
                        Posicion = (int)x.Element("Posicion")
                    };
                })
                .OrderBy(le => le.Estado) 
                .ThenBy(le => le.Posicion)
                .ToList();
        }

        public BEListaEspera ListarObjeto(BEListaEspera o)
        {
            return ListarTodo().FirstOrDefault(p => p.Id == o.Id);
        }

        public bool VerificarExistenciaObjeto(BEListaEspera o)
        {
            CrearXMLSiNoExiste();

            return _doc.Root.Element("ListasEspera").Elements("ListaEspera")
                .Any(x => (long)x.Attribute("Id") == o.Id);
        }

        public long ObtenerUltimoId()
        {
            CrearXMLSiNoExiste();
            var nodos = _doc.Root.Element("ListasEspera").Elements("ListaEspera");
            return nodos.Any() ? nodos.Max(x => (long)x.Attribute("Id")) : 0;
        }

        private int CalcularSiguientePosicion()
        {
            var nodos = _doc.Root.Element("ListasEspera").Elements("ListaEspera");
            if (!nodos.Any()) return 1;
            return nodos.Max(x => (int)x.Element("Posicion")) + 1;
        }
    }
}
