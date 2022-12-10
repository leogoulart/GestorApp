using GestorApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorApp.Services
{
    public class GestorDataStore : IDataStore<Client>
    {
        readonly List<Client> clients;

        public GestorDataStore()
        {
            clients = new List<Client>();
        }

        public Task<bool> UpdateClientAsync(Client client)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddClientAsync(Client client)
        {
            foreach(Client c in clients)
            {
                if (c.ClientName.Equals(client.ClientName))
                {
                    await App.Current.MainPage.DisplayAlert("Application Error", "A customer with that name already exists!", "Ok");
                    return await Task.FromResult(false);
                }
            }

            clients.Add(client);

            return await Task.FromResult(true);
        }

        public Task<bool> DeleteClientAsync(byte id)
        {
            throw new NotImplementedException();
        }

        public Task<Client> GetClientAsync(byte id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(clients);
        }
    }
}
