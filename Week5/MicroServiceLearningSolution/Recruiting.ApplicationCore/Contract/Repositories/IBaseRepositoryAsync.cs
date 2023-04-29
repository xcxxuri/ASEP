using System;
namespace Recruiting.ApplicationCore.Contract.Repositories
{
    public interface IBaseRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);

        ////Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter);
        //Task<T> GetByIdAsync(int id);
        ////Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null);
        //Task<int> InsertAsync(T entity);
        ////Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        //Task<int> UpdateAsync(T entity);
    }
}

