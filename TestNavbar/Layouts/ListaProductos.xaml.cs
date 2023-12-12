using TestNavbar.Models.Producto;
using TestNavbar.Services;
using TestNavbar.Pages;

namespace TestNavbar.Layouts;

public partial class ListaProductos : ContentView
{
    private ApiService _apiService = new ApiService();
    private Comida[] Comidas = new Comida[0];
    private Combo[] Combos = new Combo[0];

    public event EventHandler<SelectedItemChangedEventArgs> ProductoDetalleClicked;

    public ListaProductos()
    {
        InitializeComponent();
    }

    public async void MostrarComidas(int idCategoria)
    {
        Comidas = await _apiService.apiProducto.FiltrarComidas(idCategoria);
        Productos.ItemsSource = Comidas;
    }

    public async void MostrarCombos(int idCategoria)
    {
        Combos = await _apiService.apiProducto.FiltrarCombos(idCategoria);
        Productos.ItemsSource = Combos;
    }

    private void OnClickShowDetalleProducto(object sender, SelectedItemChangedEventArgs e)
    {
         ProductoDetalleClicked?.Invoke(this, e);
    }
}