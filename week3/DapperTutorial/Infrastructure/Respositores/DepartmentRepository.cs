using System;
using System.Data;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Dapper;

namespace Infrastructure.Respositores
{
    public interface DepartmentRepository : IRepository<Departments>
    {

        public DepartmentRepository GetById(int id)
        {
            throw new NotImplementedException();
        }
        public int Insert(Departments obj)
        {
            IDbConnection conn = _dbcontext.GetConnection();
            return conn.Execute("insert into Departments Values(@DeptName,@Location)", obj);
        }

        public void AddDepartment(Departments obj)
        {
            Departments d = new Departments();
            Console.Write("Enter Department Name:");
            d.DeptName = Console.ReadLine();
            Console.Write("Enter Department Location:");
            d.Location = Console.ReadLine();

        }
       
    }
}

