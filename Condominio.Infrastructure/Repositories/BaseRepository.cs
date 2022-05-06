using Condominio.Core.Entities;
using Condominio.Core.Interfaces;
using Condominio.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominio.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(DataContext dataContext)
        {
            _context = dataContext;
            _entities = dataContext.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

        public async Task<T> GetByStatus(Status status)
        {
            return await _entities.FindAsync(status);
        }
    }
}
