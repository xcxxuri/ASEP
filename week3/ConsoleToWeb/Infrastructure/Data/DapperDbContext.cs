using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Data
{
    // basically represent the database
    public class DapperDbContext
    {
        // IDbConnection is to link C# code to the database
        IDbConnection dbConnection;
        public DapperDbContext()
        { }

        // put the connection string here because if we put it in constructor, it will only be called once and it will not be able to get connection after a single call
        public IDbConnection GetConnection()
        {
            // mac version connection string   
            dbConnection = new SqlConnection("Server=localhost;Database=MarchDapper23;Trusted_Connection=false;TrustServerCertificate=True;User Id=sa;Password=Pa$$w0rd2019;");
            return dbConnection;
        }

    }
}

