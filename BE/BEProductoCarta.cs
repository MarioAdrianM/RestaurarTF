namespace BE
{
    public class BEProductoCarta : BEEntidad
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }   // Plato, Bebida, Postre
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public bool Activo { get; set; } = true;
    }
}
