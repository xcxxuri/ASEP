using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Dapper;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : class
    {
        protected readonly InterviewDbContext DbContext;
        public BaseRepositoryAsync(InterviewDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            // using (var connection = DbContext.GetConnection())
            using (var connection = DbContext.CreateConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name}";
                return await connection.QueryAsync<T>(query);
            }
            // throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int id)
        {
            //using (var connection = DbContext.GetConnection())
            using (var connection = DbContext.CreateConnection())
            {
                var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
                return await connection.ExecuteAsync(query, new { Id = id });
            }
            // throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            //using (var connection = DbContext.GetConnection())
            using (var connection = DbContext.CreateConnection())
            {
                var query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
                return await connection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
            }
            // throw new NotImplementedException();
        }

        public async Task<int> InsertAsync(T entity)
        {
            // get all properties of entity
            var properties = entity.GetType().GetProperties();

            // get all property names
            var columns = string.Join(",", properties.Select(p => p.Name));
            // get all property values
            var values = string.Join(",", properties.Select(p => $"@{p.Name}"));
            // build query
            var query = $"INSERT INTO {typeof(T).Name} ({columns}) VALUES ({values})";

            //using (var connection = DbContext.GetConnection())
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
            // throw new NotImplementedException();

        }

        public async Task<int> UpdateAsync(T entity)
        {
            var properties = entity.GetType().GetProperties();
            var columns = string.Join(",", properties.Select(p => $"{p.Name} = @{p.Name}"));
            var query = $"UPDATE {typeof(T).Name} SET {columns} WHERE Id = @Id";

            //using (var connection = DbContext.GetConnection())
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
            // throw new NotImplementedException();
        }
    }
}

