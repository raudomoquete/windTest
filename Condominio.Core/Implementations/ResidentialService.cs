using Condominio.Core.Entities;
using Condominio.Core.Exceptions;
using Condominio.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Core.Implementations
{
    public class ResidentialService : IResidential
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentialService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Residential> GetResidential(int id)
        {
            return await _unitOfWork.ResidentialRepository.GetById(id);
        }

        public IEnumerable<Residential> GetResidentials()
        {
            return _unitOfWork.ResidentialRepository.GetAll();
        }

        public async Task InsertResidential(Residential residential)
        {
            var client = await _unitOfWork.ClientRepository.GetById(residential.ClientId);
            if (client == null)
            {
                throw new BusinessException("el cliente no existe");
            }

            var clientResidential = await _unitOfWork.ResidentialRepository.GetResidentialsByClient(residential.ClientId);
            if (clientResidential.Count() > 0)
            {
                var lastResidential = clientResidential.OrderByDescending(x => x.CreatedDate).FirstOrDefault();
            }

            await _unitOfWork.ResidentialRepository.Add(residential);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateResidential(Residential residential)
        {
            _unitOfWork.ResidentialRepository.Update(residential);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteResidential(int id)
        {
            await _unitOfWork.ResidentialRepository.Delete(id);
            return true;
        }
    }
}
