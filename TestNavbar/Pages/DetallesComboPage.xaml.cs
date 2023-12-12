using TestNavbar.Models;
using TestNavbar.Models.Producto;
using TestNavbar.ModelViews;
using TestNavbar.Services;

namespace TestNavbar.Pages;

public partial class DetallesComboPage : ContentPage
{
    private Combo _combo;
    private Sesion _sesion = Sesion.Singleton();
    private ApiService _apiService = new ApiService();
    private ComidaCombo[] comidasCombo;
    private List<int> idComidasCombo = new List<int>();

    private Exception _emptyText = new Exception("Campo de texto en blanco");

    public DetallesComboPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        _combo = BindingContext as Combo;
        await InicializarComidasCombo();
        titulo.Text = _combo.Nombre;
        descripcion.Text = _combo.Descripcion;
        descuento.Text = (_combo.Descuento * 100).ToString() + "%";
    }

    private async Task InicializarComidasCombo()
    {
        comidasCombo = await _apiService.apiProducto.ObtenerComidasCombo(_combo.Id);
        List<ModelViewComidaCombo> comidas = new List<ModelViewComidaCombo>();
        foreach (var comidaCombo in comidasCombo)
        {
            ModelViewComidaCombo mvComidaCombo = new ModelViewComidaCombo();
            await mvComidaCombo.Inicializar(comidaCombo);
            comidas.Add(mvComidaCombo);
            idComidasCombo.Add(comidaCombo.IdComida);
        }
        ListaProductos.ItemsSource = comidas.ToArray();
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
                await _apiService.apiCarrito.AgregarComboCarrito(_sesion.IdOrden, _combo.Id, cant, idComidasCombo.ToArray());
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