namespace BE
{
    public class BEDetalleComanda
    {
        public int Linea { get; set; }           
        public long Id_Producto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public bool Enviado { get; set; }           
        public bool Preparado { get; set; }         
        public bool Anulado { get; set; }
        public string MotivoAnulacion { get; set; }

    }
}
