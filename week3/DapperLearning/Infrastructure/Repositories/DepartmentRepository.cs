using System;
using System.Data;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    // the repository use to perform CRUD operations and connect to the database
    public class DepartmentRepository : IRepository<Departments>
    {
        // _dbcontext here is to get connection to the database
        private readonly DapperDbContext _dbcontext;

        public DepartmentRepository()
        {
            // call the DapperDbContext to get connection within the repository
            _dbcontext = new DapperDbContext();
        }

        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Execute("DELETE FROM Departments WHERE Id = @Id", new { Id = id } );
            }

        }

        public IEnumerable<Departments> GetAll()
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Query<Departments>("SELECT * FROM Departments");
            }
            
        }

        public Departments GetById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {   // the second parameter in QuerySingleOrDefault is the parameter to pass to the sql statement 
                return conn.QuerySingleOrDefault<Departments>("SELECT * FROM Departments WHERE Id = @Id", new { Id = id });
            }
        }

        public int Insert(Departments obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                // Execute is a Dapper method 
                // DeptName and  Location are local variables in sql, they get their values from obj.DeptName and obj.Location
                // here we use @DeptName, @Location to paremeterize the sql statement, to prevent sql injection
                return conn.Execute("INSERT INTO Departments (DeptName, Location) VALUES (@DeptName, @Location)", obj);
            }

        }

        public int Update(Departments obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Execute("UPDATE Departments SET DeptName = @DeptName, Location = @Location WHERE Id = @Id", obj);
            }
        }
    }
}

