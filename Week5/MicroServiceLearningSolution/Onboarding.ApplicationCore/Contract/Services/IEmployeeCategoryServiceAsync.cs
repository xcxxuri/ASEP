using System;
using Onboarding.ApplicationCore.Models;

namespace Onboarding.ApplicationCore.Contract.Services
{
    public interface IEmployeeCategoryServiceAsync
    {
        Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategoryAsync();
        Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id);
        Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel employeeCategory);
        Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel employeeCategory);
        Task<int> DeleteEmployeeCategoryAsync(int id);
    }
}

