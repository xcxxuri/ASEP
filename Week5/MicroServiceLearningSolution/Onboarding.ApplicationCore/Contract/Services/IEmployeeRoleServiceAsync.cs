using System;
using Onboarding.ApplicationCore.Models;

namespace Onboarding.ApplicationCore.Contract.Services
{
    public interface IEmployeeRoleServiceAsync
    {
        Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync();
        Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id);
        Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel employeeRole);
        Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel employeeRole);
        Task<int> DeleteEmployeeRoleAsync(int id);
    }
}

