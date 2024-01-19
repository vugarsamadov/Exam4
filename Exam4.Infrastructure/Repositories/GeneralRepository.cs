using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Core.Entities;
using Exam4.Infrastructure.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Exam4.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private ApplicationDbContext _dbContext { get; }

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(int? page, int? perPage, bool includeDeleted, params string[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            
            if (!includeDeleted)
                query = query.Where(e=>e.IsDeleted == false);

            if(page != null && perPage != null)
                query = query.Skip(((int)page-1)*(int)perPage).Take((int)perPage);

            if (includes != null && includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, bool tracking, params string[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            if(includes != null && includes.Length > 0)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

    }
}
