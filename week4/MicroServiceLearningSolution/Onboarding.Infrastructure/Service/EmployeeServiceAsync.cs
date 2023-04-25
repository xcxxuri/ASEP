using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Contract.Services;
using Onboarding.ApplicationCore.Entities;
using Onboarding.ApplicationCore.Models;
using Onboarding.Infrastructure.Helper;

namespace Onboarding.Infrastructure.Service
{
	public class EmployeeServiceAsync : IEmployeeServiceAsync
	{
        private readonly IEmployeeRepositoryAsync _employeeRepositoryAsync;
		public EmployeeServiceAsync(IEmployeeRepositoryAsync employeeRepositoryAsync)
        {
            _employeeRepositoryAsync = employeeRepositoryAsync;
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllEmployeeAsync()
        {
            var employee = await _employeeRepositoryAsync.GetAllAsync();
            var response = employee.Select(x => x.ToEmployeeResponseModel());
            return response;

        }

        public async Task<EmployeeResponseModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepositoryAsync.GetByIdAsync(id);
            var response = employee.ToEmployeeResponseModel();
            return response;
        }

        public async Task<int> AddEmployeeAsync(EmployeeRequestModel model)
        {
            var existingEmployee = await _employeeRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployee != null)
            {
                throw new Exception("Id is already used");
            }
            Employee employee = new Employee();
            if (model != null)
            {
                employee = model.ToEmployee(false);
            }
            return await _employeeRepositoryAsync.InsertAsync(employee);

        }

        public async Task<int> UpdateEmployeeAsync(EmployeeRequestModel model)
        {
            var existingEmployee = await _employeeRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployee == null)
            {
                throw new Exception("Employee does not exist");
            }
            if (model != null)
            {
                Employee employee = model.ToEmployee(true);
                return await _employeeRepositoryAsync.UpdateAsync(employee);
            }
            return 0;
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var existingEmployee = await _employeeRepositoryAsync.GetByIdAsync(id);
            if (existingEmployee == null)
            {
                throw new Exception("Employee does not exist");
            }
            return await _employeeRepositoryAsync.DeleteAsync(id);
        }
        
	}
}

