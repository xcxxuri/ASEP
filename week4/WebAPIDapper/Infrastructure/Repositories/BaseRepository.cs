using System;
using ApplicationCore.Contracts.Repositories;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DapperDbContext _dbcontext;
        public BaseRepository(DapperDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public int DeleteById(int id)
        {
            using (var connection = _dbcontext.GetConnection())
            {
                var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
                return connection.Execute(query, new { Id = id });
            }
            
        }

        public IEnumerable<T> GetAll()
        {
            using (var connection = _dbcontext.GetConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name}";
                return connection.Query<T>(query);
            }
        }

        public T GetById(int id)
        {
            using (var connection = _dbcontext.GetConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
                return connection.QueryFirstOrDefault<T>(query, new { Id = id });
            }
        }

        public int Insert(T obj)
        {
            var properties = obj.GetType().GetProperties();
            var columns = string.Join(",", properties.Select(p => p.Name));
            var values = string.Join(",", properties.Select(p => $"@{p.Name}"));
            var query = $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values})";
            using (var connection = _dbcontext.GetConnection())
            {
                return connection.Execute(query, obj);
            }
        }

        public int Update(T obj)
        {
            var properties = obj.GetType().GetProperties();
            var columns = string.Join(",", properties.Select(p => $"{p.Name} = @{p.Name}"));
            var query = $"UPDATE {typeof(T).Name} SET {columns} WHERE Id = @Id";
            using (var connection = _dbcontext.GetConnection())
            {
                return connection.Execute(query, obj);
            }
            
        }
    }
}

