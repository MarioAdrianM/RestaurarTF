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
    public class MPPReserva : IGestor<BEReserva>
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPReserva()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");

        }
        private void CrearXMLSiNoExiste()
        {
            if (!File.Exists(_ruta))
            {
                _doc = new XDocument(
                    new XElement("Root",
                        new XElement("Reservas")
                    )
                );
                _doc.Save(_ruta);
            }
            else
            {
                _doc = XDocument.Load(_ruta);
                if (_doc.Root.Element("Reservas") == null)
                {
                    _doc.Root.Add(new XElement("Reservas"));
                    _doc.Save(_ruta);
                }
            }
        }

        

        public bool CrearXML()
        {
            CrearXMLSiNoExiste();
            return true;
        }

        public bool Guardar(BEReserva o)
        {
            CrearXMLSiNoExiste();

            

            if (o.Id == 0)
            {
                o.Id = ObtenerUltimoId()+1;
                

                var xRes = new XElement("Reserva",
                    new XAttribute("Id", o.Id),
                    new XElement("FechaHora", o.FechaHora.ToString("o")),
                    new XElement("DuracionMinutos", o.DuracionMinutos),
                    new XElement("CantidadPersonas", o.CantidadPersonas),
                    new XElement("IdMesa", o.IdMesa.HasValue ? o.IdMesa.Value : 0),
                    new XElement("Estado", (int)o.Estado),
                    new XElement("UsuarioCreador", o.UsuarioCreador ?? string.Empty),
                    new XElement("Observaciones", o.Observaciones ?? string.Empty),
                    new XElement("NombreCliente", o.NombreCliente ?? string.Empty),
                    new XElement("Telefono", o.Telefono ?? string.Empty)
                );

                _doc.Root.Element("Reservas").Add(xRes);
            }
            else
            {
                var xRes = _doc.Root.Element("Reservas").Elements("Reserva")
                    .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

                if (xRes == null)
                    throw new Exception("No se encontró la reserva para modificar.");

                xRes.Element("FechaHora").Value = o.FechaHora.ToString("o", CultureInfo.InvariantCulture);
                xRes.Element("DuracionMinutos").Value = o.DuracionMinutos.ToString();
                xRes.Element("CantidadPersonas").Value = o.CantidadPersonas.ToString();
                xRes.Element("IdMesa").Value = o.IdMesa.HasValue ? o.IdMesa.Value.ToString() : "0";
                xRes.Element("Estado").Value = ((int)o.Estado).ToString();
                xRes.Element("UsuarioCreador").Value = o.UsuarioCreador ?? string.Empty;
                xRes.Element("Observaciones").Value = o.Observaciones ?? string.Empty;
                xRes.Element("NombreCliente").Value = o.NombreCliente ?? string.Empty;
                xRes.Element("Telefono").Value = o.Telefono ?? string.Empty;
            }

            _doc.Save(_ruta);
            return true;
        }

        public bool Eliminar(BEReserva o)
        {
            CrearXMLSiNoExiste();
            var xRes = _doc.Root.Element("Reservas").Elements("Reserva")
                .FirstOrDefault(x => (long)x.Attribute("Id") == o.Id);

            if (xRes != null)
            {
                xRes.Remove();
                _doc.Save(_ruta);
            }
            return true;
        }

        public List<BEReserva> ListarTodo()
        {
            CrearXMLSiNoExiste();

            return _doc.Root.Element("Reservas")
                .Elements("Reserva")
                .Select(x =>
                {
                    DateTime fecha;
                    var fechaStr = (string)x.Element("FechaHora") ?? DateTime.Now.ToString("o");
                    if (!DateTime.TryParse(fechaStr, null, DateTimeStyles.RoundtripKind, out fecha))
                    {
                        DateTime.TryParse(fechaStr, new CultureInfo("es-AR"), DateTimeStyles.None, out fecha);
                    }

                    long idMesa = 0;
                    var elMesa = x.Element("IdMesa");
                    if (elMesa != null)
                        long.TryParse(elMesa.Value, out idMesa);

                    int estadoInt = 0;
                    var elEstado = x.Element("Estado");
                    if (elEstado != null)
                        int.TryParse(elEstado.Value, out estadoInt);

                    return new BEReserva
                    {
                        Id = (long)x.Attribute("Id"),
                        FechaHora = fecha,
                        DuracionMinutos = (int)x.Element("DuracionMinutos"),
                        CantidadPersonas = (int)x.Element("CantidadPersonas"),
                        IdMesa = (idMesa == 0) ? (long?)null : idMesa,
                        Estado = (EstadoReserva)estadoInt,
                        UsuarioCreador = (string)x.Element("UsuarioCreador") ?? string.Empty,
                        Observaciones = (string)x.Element("Observaciones") ?? string.Empty,
                        NombreCliente = (string)x.Element("NombreCliente") ?? string.Empty,
                        Telefono = (string)x.Element("Telefono") ?? string.Empty
                    };
                })
                .ToList();
        }
        public BEReserva ListarObjeto(BEReserva o)
        {
            return ListarTodo().FirstOrDefault(p => p.Id == o.Id);
        }

        public bool VerificarExistenciaObjeto(BEReserva o)
        {
            CrearXMLSiNoExiste();



            return _doc.Root.Element("Reservas").Elements("Reserva")
                .Any(x => (long)x.Attribute("Id") == o.Id);
        }

        public long ObtenerUltimoId()
        {
            CrearXMLSiNoExiste();
            var nodos = _doc.Root.Element("Reservas").Elements("Reserva");
            return nodos.Any() ? nodos.Max(x => (long)x.Attribute("Id")) : 0;
        }
    }
}
