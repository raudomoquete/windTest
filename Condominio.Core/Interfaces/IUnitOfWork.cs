using Condominio.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IResidentialRepository ResidentialRepository { get; }

        IRepository<Client> ClientRepository { get; }

        IRepository<Due> DueRepository { get; }

        IRepository<Payment> PaymentRepository { get; }

        IRepository<Status> StatusRepository { get; }


        void SaveChanges();

        Task SaveChangesAsync();
    }
}
