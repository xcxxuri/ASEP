using System;
using Onboarding.ApplicationCore.Models;

namespace Onboarding.ApplicationCore.Contract.Services
{
    public interface IEmployeeServiceAsync
    {
        Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync();
        Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployeeAsync(EmployeeRequestModel employee);
        Task<int> UpdateEmployeeAsync(EmployeeRequestModel employee);
        Task<int> DeleteEmployeeAsync(int id);
    }
}

