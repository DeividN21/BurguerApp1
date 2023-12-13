using BurguerApp.Layouts;
using TestNavbar.Layouts;
using TestNavbar.Models;
using TestNavbar.Models.Orden;
using TestNavbar.Pages;
using TestNavbar.Services;

namespace TestNavbar
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiService _apiService = new ApiService();
        // NAVBAR
        private NavbarLayout nav = new NavbarLayout();
        // PAGINAS
        private Inicio inicio = new Inicio();
        private AcercaDe acercaDe = new AcercaDe();
        private Menu menu = new Menu();

        private StackLayout mainLayout = new StackLayout();
        public MainPage()
        {
            InitializeComponent();
            AddYourContentView();
            nav.InicioButtonClicked += NavbarLayout_InicioButtonPressed;
            nav.AcercaDeButtonClicked += NavbarLayout_AcercaDeButtonPressed;
            nav.MenuButtonClicked += NavbarLayout_MenuButtonPressed;
            nav.CarritoButtonClicked += NavbarLayout_CarritoButtonPressed;
            nav.CerrarSesionButtonClicked += NavbarLayout_CerrarSesionButtonPressed;
            nav.OrdenesBurronCliked += NavbarLayout_OrdenesButtonPressed;
        }
        private void NavbarLayout_InicioButtonPressed(object sender, EventArgs e)
        {
            mainLayout.Children.Clear();
            mainLayout.Children.Add(nav);
            mainLayout.Children.Add(inicio);
        }

        private void NavbarLayout_AcercaDeButtonPressed(object sender, EventArgs e)
        {
            mainLayout.Children.Clear();
            mainLayout.Children.Add(nav);
            mainLayout.Children.Add(acercaDe);
        }

        private void NavbarLayout_MenuButtonPressed(object sender, EventArgs e)
        {
            mainLayout.Children.Clear();
            mainLayout.Children.Add(nav);
            mainLayout.Children.Add(menu);
        }

        private async void NavbarLayout_CarritoButtonPressed(object sender, EventArgs e)
        {
            Orden orden = await _apiService.apiOrden.ObtenerOrden(Sesion.Singleton().IdOrden);
            if (orden != null) 
            {
                await Navigation.PushModalAsync(new CarritoPage()
                {
                    BindingContext = orden
                });
            }
        }

        private void NavbarLayout_CerrarSesionButtonPressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new InicioSesionPage());
        }

        private void NavbarLayout_OrdenesButtonPressed(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new OrdenPage());
        }

        private void AddYourContentView()
        {
            ScrollView scrollView = new ScrollView();

            mainLayout.Spacing = 10;
            mainLayout.Children.Add(nav);
            mainLayout.Children.Add(inicio);

            scrollView.Content = mainLayout;

            Content = scrollView;
        }
    }
}