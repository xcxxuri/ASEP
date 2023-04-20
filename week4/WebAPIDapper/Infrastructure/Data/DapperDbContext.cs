using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Data
{
	public class DapperDbContext
	{
        IDbConnection _connection;
        public DapperDbContext()
        {
            
        }
        public IDbConnection GetConnection()
        {
            // mac version connection string   
            IDbConnection dbConnection = new SqlConnection("Server=localhost;Database=Recuriting;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=Pa$$w0rd2019;");
            return dbConnection;
        }
	}
}

