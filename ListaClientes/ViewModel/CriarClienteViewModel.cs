using ListaClientes.Models;
using ListaClientes.View;
using ListaClientes.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CriarClienteViewModel : INotifyPropertyChanged
{
    public string Nome { get; set; }
    public string CorHex { get; set; }
    public string NomeFantasia { get; set; }

    public Command SalvarCommand { get; }

    public CriarClienteViewModel()
    {
        SalvarCommand = new Command(Salvar);
    }

    private async void Salvar()
    {
        
        var novoCliente = new Clientes
        {
            Nome = this.Nome,
            CorHex = this.CorHex,
            NomeFantasia = this.NomeFantasia
        };

        
        if (Application.Current.MainPage.Navigation.NavigationStack.FirstOrDefault() is ListaClienteView listaClienteView)
        {
            if (listaClienteView.BindingContext is ListaClienteViewModel listaClienteViewModel)
            {
                listaClienteViewModel.Clientes.Add(novoCliente);
                listaClienteViewModel.RealizarPesquisa();  // Atualiza a lista de filtrados
            }
        }

       
        await Application.Current.MainPage.Navigation.PopAsync();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

