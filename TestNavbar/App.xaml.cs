using TestNavbar.Pages;
namespace TestNavbar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new InicioSesionPage();
        }
    }
}