using System;
namespace ApplicationCore.Contracts.Repositories
{
	public interface IRepository<T> where T : class
	{
        int Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetById(int id);
        


        IEnumerable<T> GetAll();


	}
}

