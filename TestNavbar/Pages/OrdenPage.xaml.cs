using TestNavbar.Models;
using TestNavbar.Models.Orden;
using TestNavbar.Services;

namespace TestNavbar.Pages;

public partial class OrdenPage : ContentPage
{
    private Orden _orden;
    private readonly ApiService _apiService = new ApiService();
    private readonly Sesion _sesion = Sesion.Singleton();

    public OrdenPage()
    {
        InitializeComponent();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _orden = BindingContext as Orden;
        await InicializarListaOrdenes();
    }

    private async Task InicializarListaOrdenes()
    {
        Orden[] ordenes = await _apiService.apiOrden.ObtenerOrdenesCliente(_sesion.IdCliente);
        Ordenes.ItemsSource = ordenes;
    }

    private void OnClickShowDetalleOrden(object sender, SelectedItemChangedEventArgs e)
    {
        Navigation.PushModalAsync(new DetalleOrdenPage()
        {
            BindingContext = e.SelectedItem as Orden
        });
    }
}