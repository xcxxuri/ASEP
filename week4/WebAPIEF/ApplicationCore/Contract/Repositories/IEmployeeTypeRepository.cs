using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contract.Repositories
{
    public interface IEmployeeTypeRepository : IBaseRepository<EmployeeType>
    {
        Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName);
    }
}

