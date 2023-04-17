using System;
namespace ApplicationCore.Contract.Repositories
{
	public interface IBaseRepository<T> where T : class
	{
        int Insert(T entity);
	}
}

