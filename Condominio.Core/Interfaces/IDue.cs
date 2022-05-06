using Condominio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IDue
    {
        IEnumerable<Due> GetDues();

        Task<Due> GetDue(int id);

        Task InsertDue(Due due);

        Task<bool> UpdateDue(Due due);
    }
}
