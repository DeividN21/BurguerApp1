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
    class ModelViewComboCarrito
    {
        private readonly ApiService _apiService = new ApiService();
        public int IdComboCarrito { get; set; }
        public string Nombre { get; set; }
        public string Cantidad { get; set; }
        public double PrecioTotal { get; set; }

        public ModelViewComboCarrito() { }

        public async Task Inicializar(ComboCarrito comboCarrito)
        {
            Combo combo = await _apiService.apiProducto.ObtenerCombo(comboCarrito.IdCombo);
            IdComboCarrito = comboCarrito.Id;
            Nombre = combo.Nombre;
            Cantidad = comboCarrito.Cantidad.ToString();
            PrecioTotal = await _apiService.apiCarrito.CalcularTotalCombo(comboCarrito.Id);
            PrecioTotal = PrecioTotal - PrecioTotal * combo.Descuento;
        }
    }
}
