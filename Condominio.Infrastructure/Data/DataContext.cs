using Condominio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Due> Dues { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Residential> Residentials { get; set; }
        public DbSet<Status> Stats { get; set; }

    }
}
