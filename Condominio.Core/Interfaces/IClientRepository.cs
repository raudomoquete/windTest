using Condominio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> GetClient(int id);

        Task<IEnumerable<Client>> GetClients();
    }
}
