using TestNavbar.Models;
using TestNavbar.Models.Persona;
using TestNavbar.Services;

namespace TestNavbar.Pages;

public partial class InicioSesionPage : ContentPage
{
    private readonly ApiService _apiService = new ApiService();
    private readonly Sesion _sesion = Sesion.Singleton();
    public InicioSesionPage()
    {
        InitializeComponent();
    }

    private async void OnClickLogin(object sender, EventArgs e)
    {
        string username = Username.Text;
        string password = Password.Text;


        Cliente cliente = await _apiService.apiUsuario.InicioSesionCliente(username, password);
        if (cliente != null)
        {
            _sesion.UsuarioLogeado = cliente.Nombre;
            _sesion.IdCliente = cliente.Id;
            Username.Text = "";
            Password.Text = "";
            await Navigation.PushModalAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Error", "Inicio de sesión fallido. Por favor verifica tus credenciales.", "OK");
        }
    }

    private void OnRegisterLinkTapped(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new RegistroPage());
    }
}