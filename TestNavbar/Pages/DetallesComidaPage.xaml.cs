using TestNavbar.Models;
using TestNavbar.Models.Producto;
using TestNavbar.Services;

namespace TestNavbar.Pages;

public partial class DetallesComidaPage : ContentPage
{

    private Comida _comida;
    private Sesion _sesion          = Sesion.Singleton();
    private ApiService _apiService  = new ApiService();
    private Exception _emptyText    = new Exception("Campo de texto en blanco");

    public DetallesComidaPage()
    {
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _comida = BindingContext as Comida;
        titulo.Text = _comida.Nombre;
        descripcion.Text = _comida.Descripcion;
        precio.Text = _comida.Precio.ToString() + " $";
    }
    private async void onClicAniadir(object sender, EventArgs e)
    {
        int cant = 0;
        if (_sesion.IdOrden == 0)
        {
            await _apiService.apiOrden.CrearOrden(_sesion.IdCliente);
            int idNuevaOrden = await _apiService.apiOrden.ObtenerNuevaOrden(_sesion.IdCliente);
            if (idNuevaOrden != 0)
                _sesion.IdOrden = idNuevaOrden;
        }
        try
        {
            if (System.String.IsNullOrEmpty(cantidad.Text)) { throw _emptyText; }
            cant = Int32.Parse(cantidad.Text);
            if (cant > 0)
                await _apiService.apiCarrito.AgregarComidaCarrito(_sesion.IdOrden, _comida.Id, cant);
            await Navigation.PopModalAsync();
        }
        catch (FormatException)
        {
            Console.WriteLine("Formato incorrecto");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    private async void onClicVolver(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}