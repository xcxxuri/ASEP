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
        // Possibly Virtual
        public async Task<T> GetByIdAsync(int id)
        {
            return await _ReDbContext.Set<T>().FindAsync(id);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
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
            _ReDbContext.Set<T>().Add(entity);
            await _ReDbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> UpdateAsync(T entity)
        {
            _ReDbContext.Entry(entity).State = EntityState.Modified;
            await _ReDbContext.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _ReDbContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _ReDbContext.Set<T>().Remove(entity);
                await _ReDbContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }



        // public int DeleteById(int id)
        // {

        //     _ReDbContext.Set<T>().Remove(_ReDbContext.Set<T>().Find(id));
        //     return _ReDbContext.SaveChanges();
            
        // }

        // public IEnumerable<T> GetAll()
        // {
        //     return _ReDbContext.Set<T>().ToList();
        // }

        // public T GetById(int id)
        // {
        //     return _ReDbContext.Set<T>().Find(id);
        // }

        // public int Insert(T obj)
        // {
        //     _ReDbContext.Set<T>().Add(obj);
        //     return _ReDbContext.SaveChanges();
        // }

        // public int Update(T obj)
        // {
        //     _ReDbContext.Set<T>().Update(obj);
        //     return _ReDbContext.SaveChanges();
        // }
    }

}

