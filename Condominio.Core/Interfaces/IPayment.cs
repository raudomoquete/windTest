using Condominio.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IPayment
    {
        IEnumerable<Payment> GetPayments();

        Task<Payment> GetPayment(int id);

        Task<Payment> GetPaymentByStatus(Status status);

        Task AddPayment(Payment payment);

        Task<bool> UpdatePayment(Payment payment);

        Task<bool> DeletePayment(int id);
    }
}
