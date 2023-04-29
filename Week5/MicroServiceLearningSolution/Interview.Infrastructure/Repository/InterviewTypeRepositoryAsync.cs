using System;
using Dapper;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
    public class InterviewTypeRepositoryAsync : BaseRepositoryAsync<InterviewType>, IInterviewTypeRepositoryAsync
    {
        public InterviewTypeRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<int> InsertAsync(InterviewType entity)
        {
            var query = $"INSERT INTO InterviewType VALUES (@Description)";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(InterviewType entity)
        {
            var query = $"UPDATE InterviewType SET Description = @Description WHERE Id = @Id";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }

    // public class InterviewType
    // {
    //     [Required]
    //     [Key]
    //     public int Id { get; set; }
    //     [Column(TypeName = "nvarchar(128)")]
    //     public string Description { get; set; }
    // }


}

