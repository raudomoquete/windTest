using Condominio.Core.Entities;
using Condominio.Core.Exceptions;
using Condominio.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Core.Implementations
{
    public class PaymentService : IPayment
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Payment> GetPayment(int id)
        {
            return await _unitOfWork.PaymentRepository.GetById(id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return _unitOfWork.PaymentRepository.GetAll();
        }

        public async Task<Payment> GetPaymentByStatus(Status status)
        {
            return await _unitOfWork.PaymentRepository.GetByStatus(status);
        }

        public async Task AddPayment(Payment payment)
        {
            var client = await _unitOfWork.ClientRepository.GetById(payment.ClientId);
            if(client == null)
            {
                throw new BusinessException("el cliente no existe");
            }

            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePayment(Payment payment)
        {
            _unitOfWork.PaymentRepository.Update(payment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePayment(int id)
        {
            var payment = await _unitOfWork.PaymentRepository.GetById(id);
            if (payment != null)
            {
                throw new BusinessException("No se pueden borrar los pagos");
            }

            return true;
        }
    }
}
