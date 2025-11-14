using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using BE;
using Backup;

namespace MPP
{
    public class MPPComanda
    {
        private readonly string _ruta;
        private XDocument _doc;

        public MPPComanda()
        {
            _ruta = GestorCarpeta.UbicacionBD("BD.Xml");
        }

        private void CargarXml()
        {
            if (!File.Exists(_ruta))
                throw new Exception("No se encontró BD.Xml");

            _doc = XDocument.Load(_ruta);

            if (_doc.Root.Element("Comandas") == null)
            {
                _doc.Root.Add(new XElement("Comandas"));
                _doc.Save(_ruta);
            }
        }

        private long ObtenerUltimoId()
        {
            CargarXml();
            var nodos = _doc.Root.Element("Comandas").Elements("Comanda");
            return nodos.Any() ? nodos.Max(x => (long)x.Attribute("Id")) : 0;
        }
        public void MarcarTodosPreparados(long idComanda)
        {
            CargarXml();
            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);
            if (nodoComanda == null) return;

            var detalles = nodoComanda.Element("Detalles")?.Elements("Detalle");
            if (detalles == null) return;

            foreach (var d in detalles)
            {
                if (d.Element("Preparado") == null)
                    d.Add(new XElement("Preparado", "true"));
                else
                    d.Element("Preparado").Value = "true";
            }

            _doc.Save(_ruta);
        }
        public bool EstaProductoEnUso(long idProducto)
        {
            CargarXml();

           
            var comandasActivas = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .Where(x =>
                {
                    string estado = (string)x.Element("Estado");
                    return estado != BEComanda.Estados.Facturada
                        && estado != BEComanda.Estados.Cerrada
                        && estado != BEComanda.Estados.Cancelada;
                });


            return comandasActivas
                .SelectMany(x => x.Element("Detalles")?.Elements("Detalle") ?? Enumerable.Empty<XElement>())
                .Any(d =>
                {
                    long pid = (long)d.Element("Id_Producto");
                    bool anulado = (bool?)d.Element("Anulado") ?? false;
                    return pid == idProducto && !anulado;
                });
        }


        public long Registrar(BEComanda comanda)
        {
            CargarXml();
            long nuevoId = ObtenerUltimoId() + 1;

            var nodo = new XElement("Comanda",
                new XAttribute("Id", nuevoId),
                new XElement("Id_Mesa", comanda.Id_Mesa),
                new XElement("Fecha", comanda.FechaHora),
                new XElement("Mozo", comanda.Mozo ?? ""),
                new XElement("Estado", comanda.Estado ?? "Abierta"),
                new XElement("Detalles")
            );

            _doc.Root.Element("Comandas").Add(nodo);
            _doc.Save(_ruta);

            return nuevoId;
        }

        public void AgregarDetalle(long idComanda, BEDetalleComanda det)
        {
            CargarXml();

            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);

            if (nodoComanda == null)
                throw new Exception("No se encontró la comanda.");

            var nodoDetalles = nodoComanda.Element("Detalles");
            if (nodoDetalles == null)
            {
                nodoDetalles = new XElement("Detalles");
                nodoComanda.Add(nodoDetalles);
            }
            int linea = nodoDetalles.Elements("Detalle").Count() + 1;
            det.Linea = linea;

            var nodoDet = new XElement("Detalle",
                new XElement("Linea", det.Linea),
                new XElement("Id_Producto", det.Id_Producto),
                new XElement("Descripcion", det.Descripcion ?? ""),
                new XElement("Cantidad", det.Cantidad),
                new XElement("PrecioUnitario", det.PrecioUnitario),
                new XElement("Enviado", "false"),
                new XElement("Preparado", "false"),
                new XElement("Anulado", "false"),
                new XElement("MotivoAnulacion", "")
            );

            nodoDetalles.Add(nodoDet);
            _doc.Save(_ruta);
        }

        public void CambiarEstado(long idComanda, string nuevoEstado)
        {
            CargarXml();

            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);

            if (nodoComanda == null)
                throw new Exception("No se encontró la comanda.");

            nodoComanda.Element("Estado").Value = nuevoEstado;
            _doc.Save(_ruta);
        }

        public List<BEComanda> ListarPendientesDeCocina()
        {
            CargarXml();

            var lista = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .Where(x => ((string)x.Element("Estado")) == "Enviada")
                .Select(x => new BEComanda
                {
                    Id = (long)x.Attribute("Id"),
                    Id_Mesa = (long)x.Element("Id_Mesa"),
                    FechaHora = (DateTime)x.Element("Fecha"),
                    Mozo = (string)x.Element("Mozo"),
                    Estado = (string)x.Element("Estado"),
                    Detalles = x.Element("Detalles") == null
                        ? new List<BEDetalleComanda>()
                        : x.Element("Detalles").Elements("Detalle")
                            .Select(d => new BEDetalleComanda
                            {
                                Linea = (int?)d.Element("Linea") ?? 0,
                                Id_Producto = (long)d.Element("Id_Producto"),
                                Descripcion = (string)d.Element("Descripcion"),
                                Cantidad = (int)d.Element("Cantidad"),
                                PrecioUnitario = (decimal)d.Element("PrecioUnitario"),
                                Enviado = (bool?)d.Element("Enviado") ?? false,
                                Preparado = (bool?)d.Element("Preparado") ?? false,
                                Anulado = (bool?)d.Element("Anulado") ?? false,
                                MotivoAnulacion = (string)d.Element("MotivoAnulacion")

                            }).ToList()
                })
                .OrderBy(x => x.FechaHora)
                .ToList();

            return lista;
        }
        public void EliminarDetalle(long idComanda, int linea)
        {
            CargarXml();
            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);
            if (nodoComanda == null) return;

            var detalle = nodoComanda.Element("Detalles")?
                .Elements("Detalle")
                .FirstOrDefault(d => ((int?)d.Element("Linea") ?? 0) == linea);

            if (detalle == null) return;

            detalle.Remove();
            _doc.Save(_ruta);
        }

        public void AnularDetalle(long idComanda, int linea, string motivo)
        {
            CargarXml();
            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);
            if (nodoComanda == null) return;

            var detalle = nodoComanda.Element("Detalles")?
                .Elements("Detalle")
                .FirstOrDefault(d => ((int?)d.Element("Linea") ?? 0) == linea);

            if (detalle == null) return;

            if (detalle.Element("Anulado") == null)
                detalle.Add(new XElement("Anulado", "true"));
            else
                detalle.Element("Anulado").Value = "true";

            if (detalle.Element("MotivoAnulacion") == null)
                detalle.Add(new XElement("MotivoAnulacion", motivo ?? ""));
            else
                detalle.Element("MotivoAnulacion").Value = motivo ?? "";

            _doc.Save(_ruta);
        }


        public void MarcarDetallePreparado(long idComanda, int linea)
        {
            CargarXml();
            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);
            if (nodoComanda == null) return;

            var detalle = nodoComanda.Element("Detalles")?
                .Elements("Detalle")
                .FirstOrDefault(d => ((int?)d.Element("Linea") ?? 0) == linea);

            if (detalle == null) return;

            if (detalle.Element("Preparado") == null)
                detalle.Add(new XElement("Preparado", "true"));
            else
                detalle.Element("Preparado").Value = "true";

            _doc.Save(_ruta);
        }

        public BEComanda ObtenerPorId(long idComanda)
        {
            CargarXml();

            var xCom = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);

            if (xCom == null) return null;

            var com = new BEComanda
            {
                Id = (long)xCom.Attribute("Id"),
                Id_Mesa = (long)xCom.Element("Id_Mesa"),
                FechaHora = (DateTime)xCom.Element("Fecha"),
                Mozo = (string)xCom.Element("Mozo"),
                Estado = (string)xCom.Element("Estado"),
                Detalles = new List<BEDetalleComanda>()
            };

            var xAudit = xCom.Element("AuditCancelacion");
            if (xAudit != null)
            {
                com.MotivoCancelacion = (string)xAudit.Element("Motivo");
                com.UsuarioCancelacion = (string)xAudit.Element("Usuario");
            }


            var xDet = xCom.Element("Detalles");
            if (xDet != null)
            {
                com.Detalles = xDet.Elements("Detalle")
                    .Select(d => new BEDetalleComanda
                    {
                        Linea = (int?)d.Element("Linea") ?? 0,
                        Id_Producto = (long)d.Element("Id_Producto"),
                        Descripcion = (string)d.Element("Descripcion"),
                        Cantidad = (int)d.Element("Cantidad"),
                        PrecioUnitario = (decimal)d.Element("PrecioUnitario"),
                        Enviado = (bool?)d.Element("Enviado") ?? false,
                        Preparado = (bool?)d.Element("Preparado") ?? false,
                        Anulado = (bool?)d.Element("Anulado") ?? false,
                        MotivoAnulacion = (string)d.Element("MotivoAnulacion")

                    }).ToList();
            }

            return com;
        }
        public List<BEComanda> Listar(DateTime? fechaFiltro = null, string estado = null)
        {
            CargarXml();

            var query = _doc.Root.Element("Comandas").Elements("Comanda");

            if (fechaFiltro.HasValue)
            {
                var f = fechaFiltro.Value.Date;
                query = query.Where(x => ((DateTime)x.Element("Fecha")).Date == f);
            }

            if (!string.IsNullOrEmpty(estado) && estado != "Todos")
            {
                query = query.Where(x => (string)x.Element("Estado") == estado);
            }

            var lista = query
                .Select(x => new BEComanda
                {
                    Id = (long)x.Attribute("Id"),
                    Id_Mesa = (long)x.Element("Id_Mesa"),
                    FechaHora = (DateTime)x.Element("Fecha"),
                    Mozo = (string)x.Element("Mozo"),
                    Estado = (string)x.Element("Estado"),
                    MotivoCancelacion = x.Element("AuditCancelacion") != null ? (string)x.Element("AuditCancelacion").Element("Motivo") : null,
                    UsuarioCancelacion = x.Element("AuditCancelacion") != null ? (string)x.Element("AuditCancelacion").Element("Usuario") : null,
                    Detalles = x.Element("Detalles") == null
                        ? new List<BEDetalleComanda>()
                        : x.Element("Detalles").Elements("Detalle")
                            .Select(d => new BEDetalleComanda
                            {
                                Linea = (int?)d.Element("Linea") ?? 0,
                                Id_Producto = (long)d.Element("Id_Producto"),
                                Descripcion = (string)d.Element("Descripcion"),
                                Cantidad = (int)d.Element("Cantidad"),
                                PrecioUnitario = (decimal)d.Element("PrecioUnitario"),
                                Enviado = (bool?)d.Element("Enviado") ?? false,
                                Preparado = (bool?)d.Element("Preparado") ?? false,
                                Anulado = (bool?)d.Element("Anulado") ?? false,
                                MotivoAnulacion = (string)d.Element("MotivoAnulacion")

                            }).ToList()
                })
                .OrderByDescending(c => c.FechaHora)
                .ToList();

            return lista;
        }
        public void MarcarDetallesEnviados(long idComanda)
        {
            CargarXml();
            var nodoComanda = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);
            if (nodoComanda == null) return;

            var detalles = nodoComanda.Element("Detalles")?.Elements("Detalle");
            if (detalles == null) return;

            foreach (var d in detalles)
            {
                var enviado = (bool?)d.Element("Enviado") ?? false;
                if (!enviado)
                    d.Element("Enviado").Value = "true";
            }

            _doc.Save(_ruta);
        }
        public bool CancelarComanda(long idComanda, string usuario, string motivo)
        {
            CargarXml();

            var nodo = _doc.Root.Element("Comandas")
                .Elements("Comanda")
                .FirstOrDefault(x => (long)x.Attribute("Id") == idComanda);

            if (nodo == null)
                throw new Exception("No se encontró la comanda a cancelar.");

            var xEstado = nodo.Element("Estado");
            if (xEstado != null) xEstado.Value = "Cancelada";
            else nodo.Add(new XElement("Estado", "Cancelada"));

            var xAudit = nodo.Element("AuditCancelacion");
            if (xAudit == null)
            {
                xAudit = new XElement("AuditCancelacion");
                nodo.Add(xAudit);
            }
            xAudit.RemoveAll();
            xAudit.Add(new XElement("Motivo", motivo ?? string.Empty));
            xAudit.Add(new XElement("Usuario", usuario ?? string.Empty));
            xAudit.Add(new XElement("Fecha", DateTime.Now));

            _doc.Save(_ruta);
            return true;
        }


        public List<BEDetalleComanda> ListarDetallesNoEnviados(long idComanda)
        {
            var com = ObtenerPorId(idComanda);
            if (com == null) return new List<BEDetalleComanda>();

            return com.Detalles.Where(d => !d.Enviado).ToList();
        }

    }
}
