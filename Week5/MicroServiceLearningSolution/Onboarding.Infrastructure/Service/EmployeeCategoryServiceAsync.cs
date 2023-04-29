using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Contract.Services;
using Onboarding.ApplicationCore.Entities;
using Onboarding.ApplicationCore.Models;
using Onboarding.Infrastructure.Helper;

namespace Onboarding.Infrastructure.Service
{
	public class EmployeeCategoryServiceAsync : IEmployeeCategoryServiceAsync
	{
        private readonly IEmployeeCategoryRepositoryAsync _employeeCategoryRepositoryAsync;
		public EmployeeCategoryServiceAsync(IEmployeeCategoryRepositoryAsync employeeCategoryRepositoryAsync)
        {
            _employeeCategoryRepositoryAsync = employeeCategoryRepositoryAsync;
        }

        public async Task<IEnumerable<EmployeeCategoryResponseModel>> GetAllEmployeeCategoryAsync()
        {
            var employeecategory = await _employeeCategoryRepositoryAsync.GetAllAsync();
            var response = employeecategory.Select(x => x.ToEmployeeCategoryResponseModel());
            return response;

        }

        public async Task<EmployeeCategoryResponseModel> GetEmployeeCategoryByIdAsync(int id)
        {
            var employeecategory = await _employeeCategoryRepositoryAsync.GetByIdAsync(id);
            var response = employeecategory.ToEmployeeCategoryResponseModel();
            return response;
        }

        public async Task<int> AddEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            var existingEmployeeCategory = await _employeeCategoryRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployeeCategory != null)
            {
                throw new Exception("Id is already used");
            }
            EmployeeCategory employeeCategory = new EmployeeCategory();
            if (model != null)
            {
                employeeCategory = model.ToEmployeeCategory(false);
            }
            return await _employeeCategoryRepositoryAsync.InsertAsync(employeeCategory);

        }

        public async Task<int> UpdateEmployeeCategoryAsync(EmployeeCategoryRequestModel model)
        {
            var existingEmployeeCategory = await _employeeCategoryRepositoryAsync.GetByIdAsync(model.Id);
            if (existingEmployeeCategory == null)
            {
                throw new Exception("Employee Category does not exist");
            }
            if (model != null)
            {
                EmployeeCategory employeeCategory = model.ToEmployeeCategory(true);
                return await _employeeCategoryRepositoryAsync.UpdateAsync(employeeCategory);
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> DeleteEmployeeCategoryAsync(int id)
        {
            var existingEmployeeCategory = await _employeeCategoryRepositoryAsync.GetByIdAsync(id);
            if (existingEmployeeCategory == null)
            {
                throw new Exception("Employee Category does not exist");
            }
            return await _employeeCategoryRepositoryAsync.DeleteAsync(id);
        }
    }
}

