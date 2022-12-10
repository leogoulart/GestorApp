using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestorApp.ViewModels
{
    [QueryProperty(nameof(ClientId), nameof(ClientId))]
    public class ClientDetailViewModel : BaseViewModel
    {
        private string _clientId;
        private string _clientName;
        private double _totalSpend;
        public string Id { get; set; }

        public string ClientName
        {
            get => _clientName;
            set => SetProperty(ref _clientName, value);
        }

        public double TotalSpend
        {
            get => _totalSpend;
            set => SetProperty(ref _totalSpend, value);
        }

        public string ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId = value;
                LoadClientId(value);
            }
        }

        public async void LoadClientId(string id)
        {
            try
            {
                var client = await DataStore.GetClientAsync(id);
                Id = client.Id;
                ClientName = client.ClientName;
                TotalSpend = client.TotalSpendings;
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Application Error!", "Falha ao carregar os dados do Cliente!\n\n" + ex.ToString(), "Ok");
                //await Shell.Current.GoToAsync("..");
            }
        }
    }
}
