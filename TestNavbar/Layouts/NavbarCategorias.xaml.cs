using TestNavbar.Models.Producto.Catalogos;
using TestNavbar.Services;

namespace TestNavbar.Layouts;

public partial class NavbarCategorias : ContentView
{
    private ApiService _apiService = new ApiService();
    public CategoriaComida[] CategoriasComida;
    public CategoriaCombo[] CategoriasCombo;

    public event EventHandler<int> CategoriaComidaButtonClicked;
    public event EventHandler<int> CategoriaComboButtonClicked;


    private HorizontalStackLayout _mainLayout;
    public NavbarCategorias()
    {
        InitializeComponent();
        Inicializar();
    }

    public async Task InicializarCategoriasComidas()
    {
        Inicializar();
        CategoriasComida = await _apiService.apiProducto.ObtenerCategoriasComida();

        foreach (var categoriaComida in CategoriasComida)
        {
            Button btn = new Button()
            {
                Text = categoriaComida.Etiqueta,
                FontFamily = "BoldFont",
                FontSize = 16,
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(111, 154, 60)
            };
            btn.Clicked += (sender, args) => onClickCategoriaComida(categoriaComida.Id);

            _mainLayout.Children.Add(btn);
        }
        ShowContent();
    }

    public async Task InicializarCategoriasCombos()
    {
        Inicializar();
        CategoriasCombo = await _apiService.apiProducto.ObtenerCategoriasCombo();

        foreach (var categoriaCombo in CategoriasCombo)
        {
            Button btn = new Button()
            {
                Text = categoriaCombo.Etiqueta,
                FontFamily = "BoldFont",
                FontSize = 16,
                TextColor = Color.FromRgb(255, 255, 255),
                BackgroundColor = Color.FromRgb(111, 154, 60)
            };
            btn.Clicked += (sender, args) => onClickCategoriaCombo(categoriaCombo.Id);
            _mainLayout.Children.Add(btn);
        }
        ShowContent();
    }

    private void Inicializar()
    {
        _mainLayout = new HorizontalStackLayout()
        {
            BackgroundColor = Color.FromRgb(232,158,63),
            Padding = 8,
            Spacing = 8,
        };
    }
    private void ShowContent()
    {
        Content = new ScrollView()
        {
            Orientation = ScrollOrientation.Horizontal,
            Content = _mainLayout
        };
    }

    private void onClickCategoriaComida(int categoriaId)
    {
        CategoriaComidaButtonClicked?.Invoke(this, categoriaId);
    }

    private void onClickCategoriaCombo(int categoriaId)
    {
        CategoriaComboButtonClicked?.Invoke(this, categoriaId);
    }

}