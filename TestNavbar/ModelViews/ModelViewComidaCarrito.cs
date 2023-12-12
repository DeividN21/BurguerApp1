using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNavbar.Models.Orden;
using TestNavbar.Models.Producto;
using TestNavbar.Services;

namespace TestNavbar.ModelViews
{
    class ModelViewComidaCarrito
    {
        private readonly ApiService _apiService = new ApiService();
        public int IdComidaCarrito { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public double PrecioTotal { get; set; }

        public ModelViewComidaCarrito() { } 

        public async Task Inicializar(ComidaCarrito comidaCarrito)
        {
            Comida comida = await  _apiService.apiProducto.ObtenerComida(comidaCarrito.IdComida);
            IdComidaCarrito = comidaCarrito.Id;
            Nombre = comida.Nombre;
            Cantidad = comidaCarrito.Cantidad.ToString();
            PrecioTotal = comidaCarrito.Cantidad * comida.Precio;
        }
    }
}
