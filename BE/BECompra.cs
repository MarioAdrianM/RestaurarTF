using System;

namespace BE
{
    public class BECompra : BEEntidad
    {
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }
        public string NumeroComprobante { get; set; }

        public BECategoriaProducto Categoria { get; set; }

        public decimal ImporteTotal { get; set; }
        public string Observaciones { get; set; }
    }
}
