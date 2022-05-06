using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using Condominio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly DataContext _context;

        public PaymentRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Payment>> GetPaymentsByClient(int clientId)
        {
            return await _entities.Where(x => x.ClientId == clientId).ToListAsync();
        }
    }
}
