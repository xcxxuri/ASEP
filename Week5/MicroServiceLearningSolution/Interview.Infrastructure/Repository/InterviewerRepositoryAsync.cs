using System;
using Dapper;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
	public class InterviewerRepositoryAsync : BaseRepositoryAsync<Interviewer>, IInterviewerRepositoryAsync
	{
		public InterviewerRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<int> InsertAsync(Interviewer entity)
        {
            var query = $"INSERT INTO Interviewer VALUES (@FirstName, @LastName, @EmployeeId)";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(Interviewer entity)
        {
            var query = $"UPDATE Interviewer SET FirstName = @FirstName, LastName = @LastName, EmployeeId = @EmployeeId WHERE Id = @Id";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
	}
}

