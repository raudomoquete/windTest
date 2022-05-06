using Condominio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IDueRepository : IRepository<Due>
    {
        Task<IEnumerable<Due>> GetDuesByClient(int clientId);
    }
}
