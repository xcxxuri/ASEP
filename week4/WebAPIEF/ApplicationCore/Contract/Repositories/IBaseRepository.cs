using System;
namespace ApplicationCore.Contract.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        // int Insert(T obj);
        // int Update(T obj);
        // int DeleteById(int id);
        // T GetById(int id);
        // IEnumerable<T> GetAll();
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        //Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
        //Task<bool> GetExistsAsync(Expression<Func<T, bool>>? filter = null);
        Task<int> InsertAsync(T entity);
        //Task<IEnumerable<T>> ListAllWithIncludesAsync(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        Task<int> UpdateAsync(T entity);
    }
}

