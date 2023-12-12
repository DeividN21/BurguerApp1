namespace TestNavbar.Models.Producto.Catalogos
{
    public class CategoriaCombo
    {
        public int Id { get; set; }
        public required string Etiqueta { get; set; }
        public Combo? Combo { get; set; }
    }
}
