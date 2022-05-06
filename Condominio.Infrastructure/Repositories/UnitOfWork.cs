using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using Condominio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly IResidentialRepository _residentialRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Due> _dueRepository;
        private readonly IRepository<Payment> _paymentRepository;
        private readonly IRepository<Status> _statusRepository;



        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IResidentialRepository ResidentialRepository => _residentialRepository ?? new ResidentialRepository(_context);

        public IRepository<Client> ClientRepository => _clientRepository ?? new BaseRepository<Client>(_context);

        public IRepository<Due> DueRepository => _dueRepository ?? new BaseRepository<Due>(_context);

        public IRepository<Payment> PaymentRepository => _paymentRepository ?? new BaseRepository<Payment>(_context);

        public IRepository<Status> StatusRepository => _statusRepository ?? new BaseRepository<Status>(_context);


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
