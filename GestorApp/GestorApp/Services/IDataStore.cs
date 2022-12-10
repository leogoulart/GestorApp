using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GestorApp.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddClientAsync(T client);
        Task<bool> UpdateClientAsync(T client);
        Task<bool> DeleteClientAsync(byte id);
        Task<T> GetClientAsync(byte id);
        Task<IEnumerable<T>> GetAllClientsAsync(bool forceRefresh = false);
    }
}
