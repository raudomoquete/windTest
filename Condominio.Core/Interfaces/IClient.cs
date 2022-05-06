using Condominio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IClient
    {
        IEnumerable<Client> GetClients();

        Task<Client> GetClient(int id);

        Task InsertClient(Client client);

        Task<bool> UpdateClient(Client client);

        Task<bool> DeleteClient(int id);
    }
}
