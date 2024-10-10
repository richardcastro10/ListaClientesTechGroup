using ListaClientes.Models;
using ListaClientes.View;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ListaClientes.ViewModel
{
    public class ListaClienteViewModel : INotifyPropertyChanged
    {
        
        public ObservableCollection<Clientes> Clientes { get; set; } = new ObservableCollection<Clientes>();

        private ObservableCollection<Clientes> _clientesFiltrados;
        public ObservableCollection<Clientes> ClientesFiltrados
        {
            get => _clientesFiltrados;
            set
            {
                _clientesFiltrados = value;
                OnPropertyChanged(nameof(ClientesFiltrados));
            }
        }

        public string PesquisaTexto { get; set; }

        // Comandos
        public Command PesquisaCommand { get; }
        public Command CadastrarCliente { get; }

        public ListaClienteViewModel()
        {
            
            ClientesFiltrados = new ObservableCollection<Clientes>(Clientes);

            PesquisaCommand = new Command(RealizarPesquisa);
            CadastrarCliente = new Command(NavegarParaCriarCliente);
        }

        public void RealizarPesquisa()
        {
            if (string.IsNullOrEmpty(PesquisaTexto))
            {
                ClientesFiltrados = new ObservableCollection<Clientes>(Clientes);
            }
            else
            {
                ClientesFiltrados = new ObservableCollection<Clientes>(
                    Clientes.Where(c => c.NomeFantasia.Contains(PesquisaTexto, StringComparison.OrdinalIgnoreCase) ||
                                        c.Nome.Contains(PesquisaTexto, StringComparison.OrdinalIgnoreCase)));
            }
        }

        private async void NavegarParaCriarCliente()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CriarClienteView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
