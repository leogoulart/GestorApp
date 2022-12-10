using GestorApp.Entities;
using GestorApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GestorApp.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        private Client _selectedClient;

        public ObservableCollection<Client> Clients { get; }
        public Command AddClientCommand { get; }
        public Command LoadClientsCommand { get; }
        public Command<Client> ClientTapped { get; }

        public ClientsViewModel()
        {
            Title = "Clients";
            Clients = new ObservableCollection<Client>();
            LoadClientsCommand = new Command(async () => await ExecuteLoadClientsCommand());
            ClientTapped = new Command<Client>(OnClientSelected);
            AddClientCommand = new Command(OnAddClient);
        }

        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                SetProperty(ref _selectedClient, value);
                OnClientSelected(value);
            }
            
        }

        async Task ExecuteLoadClientsCommand()
        {

            IsBusy = true;

            try
            {
                Clients.Clear();
                var clients = await DataStore.GetAllClientsAsync(true);
                foreach(var client in clients)
                {
                    Clients.Add(client);
                }
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Application Error!", ex.ToString(), "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            _selectedClient = null;
        }

        private async void OnAddClient(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewClientPage));
        }

        async void OnClientSelected(Client client)
        {
            if (client == null)
                return;


        }
    }
}
