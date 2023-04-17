using System;
using System.Data;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<Employees>
    {

        private readonly DapperDbContext _dbcontext;
        public EmployeeRepository()
        {
            _dbcontext = new DapperDbContext();
        }

        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Execute("DELETE FROM Employees WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Employees> GetAll()
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Query<Employees>("SELECT * FROM Employees");
            }
        }

        public Employees GetById(int id)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.QuerySingleOrDefault<Employees>("SELECT * FROM Employees WHERE Id = @Id", new { Id = id });
            }
        }

        public int Insert(Employees obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Execute("INSERT INTO Employees (FirstName, LastName, Salary, DeptId) VALUES (@FirstName, @LastName, @Salary, @DeptId)", obj);
            }
        }

        public int Update(Employees obj)
        {
            using (IDbConnection conn = _dbcontext.GetConnection())
            {
                return conn.Execute("UPDATE Employees SET FirstName = @FirstName, LastName = @LastName, Salary = @Salary, DeptId = @DeptId WHERE Id = @Id", obj);
            }
        }
    }
}

