using System;
namespace ApplicationCore.Contract.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        // int Insert(T entity);

        Task<int> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
    }
}

