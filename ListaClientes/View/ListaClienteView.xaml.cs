using ListaClientes.ViewModel;

namespace ListaClientes.View;

public partial class ListaClienteView : ContentPage
{
	public ListaClienteView()
	{
		InitializeComponent();

		BindingContext = new ListaClienteViewModel();
	}
}