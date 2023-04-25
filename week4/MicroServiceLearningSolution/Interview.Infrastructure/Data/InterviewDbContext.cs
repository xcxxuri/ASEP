using System;
using System.Data;
using System.Data.SqlClient;
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
}

