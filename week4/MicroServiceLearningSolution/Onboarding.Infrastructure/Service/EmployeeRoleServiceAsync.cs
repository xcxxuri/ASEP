using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Contract.Services;
using Onboarding.ApplicationCore.Entities;
using Onboarding.ApplicationCore.Models;
using Onboarding.Infrastructure.Helper;

namespace Onboarding.Infrastructure.Service
{
	public class EmployeeRoleServiceAsync : IEmployeeRoleServiceAsync
	{
        private readonly IEmployeeRoleRepositoryAsync _employeeRoleRepositoryAsync;
        public EmployeeRoleServiceAsync(IEmployeeRoleRepositoryAsync employeeRoleRepositoryAsync)
        {
            _employeeRoleRepositoryAsync = employeeRoleRepositoryAsync;
        }

        public async Task<IEnumerable<EmployeeRoleResponseModel>> GetAllEmployeeRoleAsync()
        {
            var employeeRoles = await _employeeRoleRepositoryAsync.GetAllAsync();
            var response = employeeRoles.Select(x => x.ToEmployeeRoleResponseModel());
            return response;

        }

        public async Task<EmployeeRoleResponseModel> GetEmployeeRoleByIdAsync(int id)
        {
            var employeeRole = await _employeeRoleRepositoryAsync.GetByIdAsync(id);
            var response = employeeRole.ToEmployeeRoleResponseModel();
            return response;
        }

        public async Task<int> AddEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            var existingEmployeeRole = await _employeeRoleRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployeeRole != null)
            {
                throw new Exception("Id is already used");
            }
            EmployeeRole employeeRole = new EmployeeRole();
            if (model != null)
            {
                employeeRole = model.ToEmployeeRole(false);
            }
            return await _employeeRoleRepositoryAsync.InsertAsync(employeeRole);

        }

        public async Task<int> UpdateEmployeeRoleAsync(EmployeeRoleRequestModel model)
        {
            var existingEmployeeRole = await _employeeRoleRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployeeRole == null)
            {
                throw new Exception("Employee Role does not exist");
            }
            if (model != null)
            {
                EmployeeRole employeeRole = model.ToEmployeeRole(true);
                return await _employeeRoleRepositoryAsync.UpdateAsync(employeeRole);
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> DeleteEmployeeRoleAsync(int id)
        {
            var existingEmployeeRole = await _employeeRoleRepositoryAsync.GetByIdAsync(id);
            if (existingEmployeeRole == null)
            {
                throw new Exception("Employee Role does not exist");
            }
            return await _employeeRoleRepositoryAsync.DeleteAsync(id);
        }
	}
}

