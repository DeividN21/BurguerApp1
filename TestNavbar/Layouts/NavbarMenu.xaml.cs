namespace TestNavbar.Layouts;

public partial class NavbarMenu : ContentView
{
    public event EventHandler CombosButtonClicked;
    public event EventHandler ComidasButtonClicked;
    public NavbarMenu()
    {
        InitializeComponent();
    }

    private void onClickCombos(object sender, EventArgs e)
    {
        CombosButtonClicked?.Invoke(this, e);
    }

    private void onClickComidas(object sender, EventArgs e)
    {
        ComidasButtonClicked?.Invoke(this, e);
    }
}