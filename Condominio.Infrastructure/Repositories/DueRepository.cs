using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using Condominio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Infrastructure.Repositories
{
    public class DueRepository : BaseRepository<Due>, IDueRepository
    {
        private readonly DataContext _context;

        public DueRepository(DataContext context) : base (context)
        {

        }

        public async Task<IEnumerable<Due>> GetDuesByClient(int clientId)
        {
            return await _entities.Where(x => x.ClientId == clientId).ToListAsync();
        }
    }
}
