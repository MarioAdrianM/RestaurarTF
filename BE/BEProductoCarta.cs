namespace BE
{
    public class BEProductoCarta : BEEntidad
    {
        public string Nombre { get; set; }
        public BECategoriaProducto Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; } = true;
    }
}
