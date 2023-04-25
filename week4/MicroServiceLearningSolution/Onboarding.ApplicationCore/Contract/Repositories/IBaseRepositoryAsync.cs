using System;
namespace Onboarding.ApplicationCore.Contract.Repositories
{
    public interface IBaseRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
    }
}

