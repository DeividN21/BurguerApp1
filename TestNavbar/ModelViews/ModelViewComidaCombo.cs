using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNavbar.Models.Producto;
using TestNavbar.Services;

namespace TestNavbar.ModelViews
{
    internal class ModelViewComidaCombo
    {
        private readonly ApiService _apiService = new ApiService();
        public string Nombre { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }

        public ModelViewComidaCombo() { }

        public async Task Inicializar(ComidaCombo comidaCombo)
        {
            Comida comida = await _apiService.apiProducto.ObtenerComida(comidaCombo.IdComida);

            Nombre = comida.Nombre;
            Precio = comida.Precio.ToString() + " $";
            Cantidad = comidaCombo.Cantidad.ToString();
        }


    }
}
