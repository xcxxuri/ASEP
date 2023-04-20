using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contract.Services
{
	public interface IEmployeeTypeService
	{
        Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model);
        Task<int> DeleteEmployeeTypeAsync(int id);
        Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypes();
        Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id);
    }
}

