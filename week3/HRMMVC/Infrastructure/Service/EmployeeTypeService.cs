using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Infrastructure.Helper;

namespace Infrastructure.Service
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        IEmployeeTypeRepository employeeTypeRepository;

        public EmployeeTypeService(IEmployeeTypeRepository _employeeTypeRepository)
        {
            employeeTypeRepository = _employeeTypeRepository;
        }

        public async Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetEmployeeTypeByTypeName(model.TypeName);
            if (existingEmployeeType != null)
            {
                throw new Exception("Employee Type already exists");
            }
            EmployeeType employeeType = new EmployeeType();
            if (model != null)
            {
                employeeType.TypeName = model.TypeName.ToLower();
            }
            return await employeeTypeRepository.InsertAsync(employeeType);
        }

        public async Task<int> DeleteEmployeeTypeAsync(int id)
        {
            return await employeeTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypes()
        {
            var employeeTypes = await employeeTypeRepository.GetAllAsync();
            var response = employeeTypes.Select(x => x.ToEmployeeTypeResponseModel());
            return response;
        }

        public async Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id)
        {
            var employeeType = await employeeTypeRepository.GetByIdAsync(id);
            if (employeeType == null)
            {
                throw new Exception("Employee Type not found");
            }
            else
            {
                return employeeType.ToEmployeeTypeResponseModel();
            }
        }

        public async Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existingEmployeeType = await employeeTypeRepository.GetEmployeeTypeByTypeName(model.TypeName);
            if (existingEmployeeType == null)
            {
                throw new Exception("Employee Type does not exists");
            }
            EmployeeType employeeType = new EmployeeType();
            if (model != null)
            {
                employeeType.TypeName = model.TypeName.ToLower();
                return await employeeTypeRepository.UpdateAsync(employeeType);
            }
            else
            {
                return -1;
            }

        }
    }
}

