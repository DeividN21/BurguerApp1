namespace TestNavbar.Models
{
    public class Sesion
    {
        //Atributos
        private static Sesion _instancia;
        public string UsuarioLogeado { get; set; }
        public int IdCliente { get; set; } = 1;
        public int IdOrden { get; set; }

        //Constructor
        private Sesion() { IdOrden = 0; }

        //Métodos
        public static Sesion Singleton()
        {
            if (_instancia == null)
            {
                _instancia = new Sesion();
            }
            return _instancia;
        }
    }
}
