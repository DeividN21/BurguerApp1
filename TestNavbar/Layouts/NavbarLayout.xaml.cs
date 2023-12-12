using TestNavbar.Models;

namespace BurguerApp.Layouts;

public partial class NavbarLayout : ContentView
{
    private readonly Sesion _sesion = Sesion.Singleton();
    public event EventHandler InicioButtonClicked;
    public event EventHandler AcercaDeButtonClicked;
    public event EventHandler MenuButtonClicked;
    public event EventHandler CarritoButtonClicked;
    public event EventHandler CerrarSesionButtonClicked;
    public event EventHandler OrdenesBurronCliked;

    public NavbarLayout()
    {
        InitializeComponent();
        Username.Text = $"Bienvenido, {_sesion.UsuarioLogeado}";
    }

    private void OnClickInicio(object sender, EventArgs e)
    {
        InicioButtonClicked?.Invoke(this, e);
    }

    private void OnClickAcerca(object sender, EventArgs e)
    {
        AcercaDeButtonClicked?.Invoke(this, e);
    }

    private void OnClickMenu(object sender, EventArgs e)
    {
        MenuButtonClicked?.Invoke(this, e);
    }

    private void OnClickCarrito(object sender, EventArgs e)
    {
        CarritoButtonClicked?.Invoke(this, e);
    }

    private void OnClickCerrarSesion(object sender, EventArgs e)
    {
        CerrarSesionButtonClicked?.Invoke(this, e);
    }

    private void OnClickOrdenes(object sender, EventArgs e)
    {
        OrdenesBurronCliked?.Invoke(this, e);
    }
}