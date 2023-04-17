using System;
namespace Infrastructure.Data
{
	public class DapperDbContext
	{
        

        IDbConnection dbConnection;
         DapperDbContext()
        {
            // use localhost not MarchDapper2023 as the server name
            dbConnection = new SqlConnection("Data Source=.;Initial Catalog=MarchDapper2023;Integrated Security=True");
        }

        public IDbConnection GetConnection()
        {
            return dbConnection;
        }


	}
}

