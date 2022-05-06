using Condominio.Core.Entities;
using Condominio.Core.Exceptions;
using Condominio.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Core.Implementations
{
    public class DueService : IDue
    {
        private readonly IUnitOfWork _unitOfWork;

        public DueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Due> GetDue(int id)
        {
           return await _unitOfWork.DueRepository.GetById(id);
        }

        public IEnumerable<Due> GetDues()
        {
            return _unitOfWork.DueRepository.GetAll();
        }

        public async Task InsertDue(Due due)
        {
            var client = await _unitOfWork.ClientRepository.GetById(due.ClientId);
            if (client == null)
            {
                throw new BusinessException("Este usuario no existe");
            }

            var clientPayment = await _unitOfWork.PaymentRepository.GetById(due.ClientId);
            _unitOfWork.PaymentRepository.Update(clientPayment);
            
            await _unitOfWork.DueRepository.Add(due);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateDue(Due due)
        {
            _unitOfWork.DueRepository.Update(due);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
