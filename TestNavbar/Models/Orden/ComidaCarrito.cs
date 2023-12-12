namespace TestNavbar.Models.Orden
{
    public class ComidaCarrito : ProductoCarrito
    {
        public int? IdComboCarrito { get; set; }
        public required int IdComida { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ComidaCarrito comida = (ComidaCarrito)obj;
            return IdComida == comida.IdComida;
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
