using System.Security.AccessControl;
using TestNavbar.Models;
using TestNavbar.Models.Orden;
using TestNavbar.ModelViews;
using TestNavbar.Services;

namespace TestNavbar.Pages;

public partial class CarritoPage : ContentPage
{
    private readonly ApiService _apiService = new ApiService();
    private readonly Sesion _sesion = Sesion.Singleton();
    private double _precioTotal = 0;
    private Orden _orden;

    private List<ModelViewComboCarrito> combos = new List<ModelViewComboCarrito>();
    private List<ModelViewComidaCarrito> comidas = new List<ModelViewComidaCarrito>();

    public CarritoPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _orden = BindingContext as Orden;
        await InicializarCombosCarrito();
        await InicializarComidasCarrito();
        PrecioTotal.Text = _precioTotal.ToString();
    }

    private async Task InicializarCombosCarrito()
    {
        ComboCarrito[] combosCarrito = await _apiService.apiCarrito.ObtenerCombos(_orden.Id);

        if (combosCarrito.Length > 0)
        {
            foreach (var comboCarrito in combosCarrito)
            {
                ModelViewComboCarrito combo = new ModelViewComboCarrito();
                await combo.Inicializar(comboCarrito);
                combos.Add(combo);
                _precioTotal += combo.PrecioTotal * comboCarrito.Cantidad;
            }
            ListaCombos.ItemsSource = combos.ToArray();
        }
    }

    private async Task InicializarComidasCarrito()
    {
        ComidaCarrito[] comidasCarrito = await _apiService.apiCarrito.ObtenerComidas(_orden.Id);

        if (comidasCarrito.Length > 0)
        {
            foreach (var comidaCarrito in comidasCarrito)
            {
                ModelViewComidaCarrito comida = new ModelViewComidaCarrito();
                await comida.Inicializar(comidaCarrito);
                comidas.Add(comida);
                _precioTotal += comida.PrecioTotal;
            }
            ListaComidas.ItemsSource = comidas.ToArray();
        }
    }

    private async void onClickComprar(object sender, EventArgs e)
    {
        _sesion.IdOrden = 0;
        await Navigation.PopModalAsync();
    }

    private async void onClickCancelar(object sender, EventArgs e)
    {
        if (combos.Count > 0)
        {
            foreach (var combo in combos)
            {
                await _apiService.apiCarrito.EliminarComboCarrito(combo.IdComboCarrito);
            }
        }

        if (comidas.Count > 0)
        {
            foreach (var comida in comidas)
            {
                await _apiService.apiCarrito.EliminarComidaCarrito(comida.IdComidaCarrito);
            }
        }

        await Navigation.PopModalAsync();
    }

    private async void onClickRegresar(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}