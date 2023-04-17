using System;
using ApplicationCore.Contract.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly RecurtingDbContext _ReDbContext;
        public BaseRepository(RecurtingDbContext dbContext)
        {
            _ReDbContext = dbContext;
        }

        public int Insert(T entity)
        {
            _ReDbContext.Set<T>().Add(entity);
            _ReDbContext.SaveChanges();
            return 1;
            
        }
    }
}

