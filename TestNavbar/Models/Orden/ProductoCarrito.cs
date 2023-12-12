namespace TestNavbar.Models.Orden
{
    public class ProductoCarrito
    {
        public int Id { get; set; }
        public required int IdOrden { get; set; }
        public required int Cantidad { get; set; }
    }
}
