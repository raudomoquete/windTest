using Condominio.Core.Entities;
using System.Threading.Tasks;

namespace Condominio.Core.Interfaces
{
    public interface IStatus
    {
        Task InsertStatus(Status status);
    }
}
