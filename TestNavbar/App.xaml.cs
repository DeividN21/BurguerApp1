using TestNavbar.Pages;
namespace TestNavbar
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Preferences.Get("IsUserLoggedIn", false))
            {
                MainPage = new MainPage();
            }
            else
            {
                MainPage = new InicioSesionPage();
            }
        }
    }
}