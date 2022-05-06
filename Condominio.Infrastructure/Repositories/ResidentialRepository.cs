using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using Condominio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Infrastructure.Repositories
{
    public class ResidentialRepository : BaseRepository<Residential>, IResidentialRepository
    {
        private readonly DataContext _context;

        public ResidentialRepository(DataContext dataContext) : base(dataContext)
        {

        }
        
        public async Task<IEnumerable<Residential>> GetResidentialsByClient(int clientId)
        {
            return await _entities.Where(x => x.ClientId == clientId).ToListAsync();
        }
    }
}
