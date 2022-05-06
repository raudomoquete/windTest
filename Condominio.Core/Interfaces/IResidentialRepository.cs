using Condominio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IResidentialRepository : IRepository<Residential>
    {
        Task<IEnumerable<Residential>> GetResidentialsByClient(int clientId);
    }
}
