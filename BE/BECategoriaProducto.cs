namespace BE
{
    public class BECategoriaProducto : BEEntidad
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; } = true;
        public override string ToString()
        {
            return Nombre;
        }
    }
}
