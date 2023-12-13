using TestNavbar.Models;
using TestNavbar.Models.Persona;
using TestNavbar.Models.Persona.Catalogos;
using TestNavbar.Services;

namespace TestNavbar.Pages;

public partial class RegistroPage : ContentPage
{
    private readonly ApiService _apiService = new ApiService();
    private readonly Sesion _sesion = Sesion.Singleton();
    private GeneroCliente[] _generos;

    public RegistroPage()
	{
		InitializeComponent();
        CargarGeneros();

    }

    private async void CargarGeneros()
    {
        _generos = await _apiService.apiUsuario.ObtenerGenerosCliente();


        Genero.ItemsSource = _generos.Select(g => g.Etiqueta).ToList();
    }

    private async void OnClickCrearCuenta(object sender, EventArgs e)
    {
        try
        {
            string existingUsername = ExistingUsername.Text;
            string existingPassword = ExistingPassword.Text;

            Cliente existingCliente = await _apiService.apiUsuario.InicioSesionCliente(existingUsername, existingPassword);
            if (existingCliente == null)
            {
                await DisplayAlert("Error", "Credenciales de cliente existente inválidas.", "OK");
                return;
            }

            // Validar datos del nuevo cliente
            string nombre = Nombre.Text;
            string apellido = Apellido.Text;
            DateTime fechaNacimiento = FechaNacimiento.Date;
            string genero = Genero.SelectedItem as string;
            string telefono = Telefono.Text;
            string mail = Mail.Text;

            GeneroCliente generoCliente = _generos.FirstOrDefault(g => g.Etiqueta == genero);
            if (generoCliente == null)
            {
                await DisplayAlert("Error", "Género seleccionado no válido", "OK");
                return;
            }


            // Crear nueva cuenta de cliente
            string newUsername = NewUsername.Text;
            string newPassword = NewPassword.Text;

            string resultado = await _apiService.apiUsuario.RegistroCuentaCliente(newUsername, newPassword, new Cliente
            {
                Nombre = nombre,
                Apellido = apellido,
                FechaNacimiento = fechaNacimiento,
                IdGenero = generoCliente.Id,
                TelefonoCliente = telefono,
                MailCliente = mail
            });

            if (resultado == "Registro exitoso")
            {
                await DisplayAlert("Éxito", "Registro exitoso. Ahora puedes iniciar sesión.", "OK");
                await Navigation.PushModalAsync(new InicioSesionPage());
            }
            else
            {
                await DisplayAlert("Error", $"Error al registrar la cuenta: {resultado}", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Error inesperado: {ex.Message}", "OK");
        }
    }
}