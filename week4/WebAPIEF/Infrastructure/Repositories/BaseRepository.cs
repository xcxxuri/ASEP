using System;
using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly RecurtingDbContext _ReDbContext;
        public BaseRepository(RecurtingDbContext dbContext)
        {
            _ReDbContext = dbContext;
        }

        public int DeleteById(int id)
        {

            _ReDbContext.Set<T>().Remove(_ReDbContext.Set<T>().Find(id));
            return _ReDbContext.SaveChanges();
            
        }

        public IEnumerable<T> GetAll()
        {
            return _ReDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _ReDbContext.Set<T>().Find(id);
        }

        public int Insert(T obj)
        {
            _ReDbContext.Set<T>().Add(obj);
            return _ReDbContext.SaveChanges();
        }

        public int Update(T obj)
        {
            _ReDbContext.Set<T>().Update(obj);
            return _ReDbContext.SaveChanges();
        }
    }

}

