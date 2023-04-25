using System;
using Onboarding.ApplicationCore.Models;

namespace Onboarding.ApplicationCore.Contract.Services
{
    public interface IEmployeeStatusServiceAsync
    {
        Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync();
        Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id);
        Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel employeeStatus);
        Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel employeeStatus);
        Task<int> DeleteEmployeeStatusAsync(int id);
    }
}

