using Condominio.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IResidential
    {
        IEnumerable<Residential> GetResidentials();

        Task<Residential> GetResidential(int id);

        Task InsertResidential(Residential residential);

        Task<bool> UpdateResidential(Residential residential);

        Task<bool> DeleteResidential(int id);
    }
}
