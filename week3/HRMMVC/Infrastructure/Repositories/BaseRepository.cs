using System;
using System.Linq.Expressions;
using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RecurtingDbContext _ReDbContext;
        public BaseRepository(RecurtingDbContext dbContext)
        {
            _ReDbContext = dbContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {

            //throw new NotImplementedException();
            // get record by id from the database
            return await _ReDbContext.Set<T>().FindAsync(id);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //throw new NotImplementedException();
            // get all records from the database

            return await _ReDbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter)
        {
            return await _ReDbContext.Set<T>().Where(filter).ToListAsync();
        }

        // For Job Requirement to include Category and other Navigation 
        public async Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] includes)
        {
            var query = _ReDbContext.Set<T>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.Where(where).ToListAsync();
        }

        // Virtual if needed. Is good to check if Id and value exists in Repo.
        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter == null) return false;
            return await _ReDbContext.Set<T>().Where(filter).AnyAsync();
        }

        public async Task<int> InsertAsync(T entity)
        {
            // Insert entity into the database
            _ReDbContext.Set<T>().Add(entity);
            await _ReDbContext.SaveChangesAsync();
            return 1;
            // var result = _ReDbContext.Set<T>().AddAsync(entity);
            // return _ReDbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _ReDbContext.Entry(entity).State = EntityState.Modified;
            await _ReDbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            //throw new NotImplementedException();
            var entity = await _ReDbContext.Set<T>().FindAsync(id);
            if(entity != null)
            {
                _ReDbContext.Set<T>().Remove(entity);
                return await _ReDbContext.SaveChangesAsync();
            }
            return 0;
        }
    }
}

