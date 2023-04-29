using System;
using System.Data;
using System.Data.SqlClient;
using Interview.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Interview.Infrastructure.Data
{
    public class InterviewDbContext
    {
        private readonly string _connectionString;

        public InterviewDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("InterviewAPIDb");
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

	// public class InterviewDbContext: DbContext
	// {
	// 	public InterviewDbContext(DbContextOptions<InterviewDbContext> option) : base (option)
	// 	{
	// 	}
    //     public DbSet<Interviewer> Interviewer { get; set; }
    //     public DbSet<Interviews>  Interviews { get; set; }
    //     public DbSet<InterviewFeedback> InterviewFeedback { get; set; }
    //     public DbSet<InterviewType> InterviewType { get; set; }
    //     public DbSet<Recruiter> Recruiter { get; set; }

	// }
}

