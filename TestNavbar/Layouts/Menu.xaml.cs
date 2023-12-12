using TestNavbar.Models.Producto;
using TestNavbar.Pages;

namespace TestNavbar.Layouts;

public partial class Menu : ContentView
{
    // NAVBAR
    private NavbarMenu navMenu = new NavbarMenu();
    private NavbarCategorias navCategorias = new NavbarCategorias();
    // PAGINAS
    ListaProductos listaProductos = new ListaProductos();

    private StackLayout mainLayout = new StackLayout();
    public Menu()
    {
        InitializeComponent();
        AddYourContentView();
        navMenu.CombosButtonClicked += NavbarMenu_CombosButtonPressed;
        navMenu.ComidasButtonClicked += NavbarMenu_ComidasButtonPressed;
        navCategorias.CategoriaComidaButtonClicked += NavbarCategorias_CategoriaComidaButtonPressed;
        navCategorias.CategoriaComboButtonClicked += NavbarCategorias_CategoriaComboButtonPressed;
        listaProductos.ProductoDetalleClicked += ListaProductos_ProductoDetallePressed;
    }


    private void InicializarEncabezadoMenu()
    {
        mainLayout = new StackLayout();
        mainLayout.Children.Add(navMenu);
    }
    private async void InicializarEncabezadoMenu_Comidas()
    {
        InicializarEncabezadoMenu();
        await navCategorias.InicializarCategoriasComidas();
        mainLayout.Children.Add(navCategorias);
    }

    private async void InicializarEncabezadoMenu_Combos()
    {
        InicializarEncabezadoMenu();
        await navCategorias.InicializarCategoriasCombos();
        mainLayout.Children.Add(navCategorias);
    }

    private void NavbarMenu_ComidasButtonPressed(object sender, EventArgs e)
    {
        InicializarEncabezadoMenu_Comidas();
    }

    private void NavbarMenu_CombosButtonPressed(object sender, EventArgs e)
    {
        InicializarEncabezadoMenu_Combos();
    }

    private void NavbarCategorias_CategoriaComidaButtonPressed(object sender, int idCategoria)
    {
        InicializarEncabezadoMenu_Comidas();
        listaProductos.MostrarComidas(idCategoria);
        mainLayout.Children.Add(listaProductos);
    }

    private void NavbarCategorias_CategoriaComboButtonPressed(object sender, int idCategoria)
    {
        InicializarEncabezadoMenu_Combos();
        listaProductos.MostrarCombos(idCategoria);
        mainLayout.Children.Add(listaProductos);
    }

    private void ListaProductos_ProductoDetallePressed(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is Comida)
        {
            Navigation.PushModalAsync(new DetallesComidaPage()
            {
                BindingContext = e.SelectedItem as Comida,
            });
        }
        else if (e.SelectedItem is Combo)
        {
            Navigation.PushModalAsync(new DetallesComboPage()
            {
                BindingContext = e.SelectedItem as Combo,
            });
        }
    }

    private void AddYourContentView()
    {
        ScrollView scrollView = new ScrollView();

        mainLayout.Spacing = 10;
        mainLayout.Children.Add(navMenu);
        mainLayout.Children.Add(navCategorias);
        mainLayout.Children.Add(listaProductos);

        scrollView.Content = mainLayout;

        Content = scrollView;
    }
}