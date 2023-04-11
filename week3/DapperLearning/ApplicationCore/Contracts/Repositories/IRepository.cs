using System;
namespace ApplicationCore.Contracts.Repositories
{
    // T is a generic type, here it is a class
    public interface IRepository<T> where T : class
    {
        int Insert(T obj);
        int Update(T obj);
        int DeleteById(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}

