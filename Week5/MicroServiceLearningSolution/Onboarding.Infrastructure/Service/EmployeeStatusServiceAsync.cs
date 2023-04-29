using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Contract.Services;
using Onboarding.ApplicationCore.Entities;
using Onboarding.ApplicationCore.Models;
using Onboarding.Infrastructure.Helper;

namespace Onboarding.Infrastructure.Service
{
	public class EmployeeStatusServiceAsync : IEmployeeStatusServiceAsync
	{
        private readonly IEmployeeStatusRepositoryAsync _employeeStatusRepositoryAsync;
		public EmployeeStatusServiceAsync(IEmployeeStatusRepositoryAsync employeeStatusRepositoryAsync)
        {
            _employeeStatusRepositoryAsync = employeeStatusRepositoryAsync;
        }

        public async Task<IEnumerable<EmployeeStatusResponseModel>> GetAllEmployeeStatusAsync()
        {
            var employeeStatuses = await _employeeStatusRepositoryAsync.GetAllAsync();
            var response = employeeStatuses.Select(x => x.ToEmployeeStatusResponseModel());
            return response;

        }

        public async Task<EmployeeStatusResponseModel> GetEmployeeStatusByIdAsync(int id)
        {
            var employeeStatus = await _employeeStatusRepositoryAsync.GetByIdAsync(id);
            var response = employeeStatus.ToEmployeeStatusResponseModel();
            return response;
        }

        public async Task<int> AddEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            var existingEmployeeStatus = await _employeeStatusRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployeeStatus != null)
            {
                throw new Exception("Id is already used");
            }
            EmployeeStatus employeeStatus = new EmployeeStatus();
            if (model != null)
            {
                employeeStatus = model.ToEmployeeStatus(false);
            }
            return await _employeeStatusRepositoryAsync.InsertAsync(employeeStatus);

        }

        public async Task<int> UpdateEmployeeStatusAsync(EmployeeStatusRequestModel model)
        {
            var existingEmployeeStatus = await _employeeStatusRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployeeStatus == null)
            {
                throw new Exception("Employee Status does not exist");
            }
            if (model != null)
            {
                EmployeeStatus employeeStatus = model.ToEmployeeStatus(true);
                return await _employeeStatusRepositoryAsync.UpdateAsync(employeeStatus);
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> DeleteEmployeeStatusAsync(int id)
        {
            var existingEmployeeStatus = await _employeeStatusRepositoryAsync.GetByIdAsync(id);
            if (existingEmployeeStatus == null)
            {
                throw new Exception("Employee Status does not exist");
            }
            return await _employeeStatusRepositoryAsync.DeleteAsync(id);
        }
	}
}

