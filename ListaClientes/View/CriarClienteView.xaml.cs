namespace ListaClientes.View;

public partial class CriarClienteView : ContentPage
{
	public CriarClienteView()
	{
		InitializeComponent();

        BindingContext = new CriarClienteViewModel();
    }
}