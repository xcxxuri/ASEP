using System;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class
    {
        protected readonly RecruitingDbContext DbContext;
        public BaseRepositoryAsync(RecruitingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await DbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                DbContext.Set<T>().Remove(entity);
                await DbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return await DbContext.SaveChangesAsync();

        }

        public async Task<int> UpdateAsync(T entity)
        {
            DbContext.Set<T>().Update(entity);
            return await DbContext.SaveChangesAsync();
        }
    }
}

