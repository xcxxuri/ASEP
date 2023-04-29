using System;
using Dapper;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
    public class RecruiterRepositoryAsync : BaseRepositoryAsync<Recruiter>, IRecruiterRepositoryAsync
    {
        public RecruiterRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<int> InsertAsync(Recruiter entity)
        {
            var query = $"INSERT INTO Recruiter VALUES (@FirstName, @LastName, @EmployeeId)";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(Recruiter entity)
        {
            var query = $"UPDATE Recruiter SET FirstName = @FirstName, LastName = @LastName, EmployeeId = @EmployeeId WHERE Id = @Id";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
    //     public class Recruiter
    // {
    //     [Required]
    //     [Key]
    //     public int Id { get; set; }
    //     [Required]
    //     [Column(TypeName = "nvarchar(128)")]
    //     public string FirstName { get; set; }
    //     [Required]
    //     [Column(TypeName = "nvarchar(128)")]
    //     public string LastName { get; set; }
    //     public int EmployeeId { get; set; }
    // }


}

