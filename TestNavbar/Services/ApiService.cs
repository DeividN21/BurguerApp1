namespace TestNavbar.Services
{
    public class ApiService
    {
        public ApiCarrito apiCarrito { get; set; } = ApiCarrito.Singleton();
        public ApiEstado apiEstado { get; set; } = ApiEstado.Singleton();
        public ApiOrden apiOrden { get; set; } = ApiOrden.Singleton();
        public ApiProducto apiProducto { get; set; } = ApiProducto.Singleton();
        public ApiUsuario apiUsuario { get; set; } = ApiUsuario.Singleton();
    }
}
