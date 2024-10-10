using ListaClientes.View;

namespace ListaClientes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListaClienteView());
        }
    }
}
