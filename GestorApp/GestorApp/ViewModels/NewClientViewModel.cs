using GestorApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GestorApp.ViewModels
{
    public class NewClientViewModel : BaseViewModel
    {
        private string _clientName;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public NewClientViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }

        public string ClientName
        {
            get => _clientName;
            set => SetProperty(ref _clientName, value);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(_clientName);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Client newClient = new Client()
            {
                Id = Guid.NewGuid().ToString(),
                ClientName = this.ClientName
            };

            await DataStore.AddClientAsync(newClient);

            await Shell.Current.GoToAsync("..");
        }
    }
}
