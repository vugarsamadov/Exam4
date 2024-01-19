using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam4.Core.Entities;

namespace Exam4.Infrastructure.Repositories.Abstract
{
    public interface IGenericRepository<T>
    {
        public Task<int> GetCountAsync();

        public Task<IEnumerable<T>> GetAllAsync(int? page, int? perPage, bool includeDeleted, params string[] includes);

        public Task<T> GetByIdAsync(int id, bool tracking,params string[] includes);

        public void Update(T entity);

        public Task SaveChangesAsync();

        public Task CreateAsync(T entity);
    }
}
