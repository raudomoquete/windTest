using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.Core.Implementations
{
    public class ClientService : IClient
    {     
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }        

        public Task<Client> GetClient(int id)
        {
            return _unitOfWork.ClientRepository.GetById(id);
        }

        public IEnumerable<Client> GetClients()
        {
            return _unitOfWork.ClientRepository.GetAll();
        }

        public async Task InsertClient(Client client)
        {
            await _unitOfWork.ClientRepository.Add(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateClient(Client client)
        {
            _unitOfWork.ClientRepository.Update(client);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClient(int id)
        {
            await _unitOfWork.ClientRepository.Delete(id);
            return true;
        }
    }
}
