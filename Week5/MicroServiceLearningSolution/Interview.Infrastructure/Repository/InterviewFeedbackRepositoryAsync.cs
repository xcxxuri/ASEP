using System;
using Dapper;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
    public class InterviewFeedbackRepositoryAsync : BaseRepositoryAsync<InterviewFeedback>, IInterviewFeedbackRepositoryAsync
    {
        public InterviewFeedbackRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
        {
        }

        // public async Task<int> InsertAsync(Interviewer entity)
        // {
        //     var query = $"INSERT INTO Interviewer VALUES (@FirstName, @LastName, @EmployeeId)";
        //     using (var connection = DbContext.CreateConnection())
        //     {
        //         return await connection.ExecuteAsync(query, entity);
        //     }
        // }

        // public async Task<int> UpdateAsync(Interviewer entity)
        // {
        //     var query = $"UPDATE Interviewer SET FirstName = @FirstName, LastName = @LastName, EmployeeId = @EmployeeId WHERE Id = @Id";
        //     using (var connection = DbContext.CreateConnection())
        //     {
        //         return await connection.ExecuteAsync(query, entity);
        //     }
        // }

        // public class InterviewFeedback
        // {
        //     [Required]
        //     public int Id { get; set; }
        //     [Required]
        //     public int Rating { get; set; }
        //     [Column(TypeName = "varchar(max)")]
        //     public string Comment { get; set; }
        // }

        public async Task<int> InsertAsync(InterviewFeedback entity)
        {
            var query = $"INSERT INTO InterviewFeedback VALUES (@Rating, @Comment)";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(InterviewFeedback entity)
        {
            var query = $"UPDATE InterviewFeedback SET Rating = @Rating, Comment = @Comment WHERE Id = @Id";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
}

