using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using ProjectRestaurant.DataAccess.Abstract.DataManagement;
using ProjectRestaurant.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.DataAccess.Concrete.EntityFramework.DataManagement
{
    public class EfRepository<T> : IRepository<T> where T : AuditableEntity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(DbContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<EntityEntry<T>> AddAsync(T Entity)
        {
            return await _dbSet.AddAsync(Entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet; 

            if (Filter != null)
            {
                query = query.Where(Filter); 
            }
            if (IncludeProperties.Length > 0)
            {
                foreach (string includeProperty in IncludeProperties) 
                {
                    query = query.Include(includeProperty);
                }
            }
            return await Task.Run(() => query);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties)
        {
            IQueryable<T> query = _dbSet;

            if (IncludeProperties.Length > 0)
            {
                foreach (string includeProperty in IncludeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.SingleOrDefaultAsync(Filter);
        }

        public async Task RemoveAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Remove(Entity));
        }

        public async Task UpdateAsync(T Entity)
        {
            await Task.Run(() => _dbSet.Update(Entity));
        }
    }
}
