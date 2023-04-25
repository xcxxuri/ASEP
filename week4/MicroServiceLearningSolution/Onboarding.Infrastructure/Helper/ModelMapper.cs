using System;
using Onboarding.ApplicationCore.Entities;
using Onboarding.ApplicationCore.Models;

namespace Onboarding.Infrastructure.Helper
{
    public static class ModelMapper
    {
        public static EmployeeStatusResponseModel ToEmployeeStatusResponseModel(this EmployeeStatus employeeStatus)
        {
            return new EmployeeStatusResponseModel
            {
                Id = employeeStatus.Id,
                Description = employeeStatus.Description,
                ABBR = employeeStatus.ABBR
            };
        }

        public static EmployeeStatus ToEmployeeStatus(this EmployeeStatusRequestModel employeeStatusRequestModel, bool hasId)
        {
            var employeeStatus = new EmployeeStatus()
            {
                Description = employeeStatusRequestModel.Description,
                ABBR = employeeStatusRequestModel.ABBR
            };
            if (hasId)
            {
                employeeStatus.Id = employeeStatusRequestModel.Id;
            }
            return employeeStatus;
        }

        public static EmployeeCategoryResponseModel ToEmployeeCategoryResponseModel(this EmployeeCategory employeeCategory)
        {
            return new EmployeeCategoryResponseModel
            {
                Id = employeeCategory.Id,
                Description = employeeCategory.Description
            };
        }

        public static EmployeeCategory ToEmployeeCategory(this EmployeeCategoryRequestModel employeeCategoryRequestModel, bool hasId)
        {
            var employeeCategory = new EmployeeCategory()
            {
                Description = employeeCategoryRequestModel.Description
            };
            if (hasId)
            {
                employeeCategory.Id = employeeCategoryRequestModel.Id;
            }
            return employeeCategory;
        }

        public static EmployeeResponseModel ToEmployeeResponseModel(this Employee employee)
        {
            return new EmployeeResponseModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                SSN = employee.SSN,
                HireDate = employee.HireDate,
                EndDate = employee.EndDate,
                EmployeeCategoryId = employee.EmployeeCategoryId,
                EmployeeStatusId = employee.EmployeeStatusId,
                EmployeeRoleId = employee.EmployeeRoleId,
                Address = employee.Address,
                Email = employee.Email
            };
        }

        public static Employee ToEmployee(this EmployeeRequestModel employeeRequestModel, bool hasId)
        {
            var employee = new Employee()
            {
                FirstName = employeeRequestModel.FirstName,
                MiddleName = employeeRequestModel.MiddleName,
                LastName = employeeRequestModel.LastName,
                SSN = employeeRequestModel.SSN,
                HireDate = employeeRequestModel.HireDate,
                EndDate = employeeRequestModel.EndDate,
                EmployeeCategoryId = employeeRequestModel.EmployeeCategoryId,
                EmployeeStatusId = employeeRequestModel.EmployeeStatusId,
                EmployeeRoleId = employeeRequestModel.EmployeeRoleId,
                Address = employeeRequestModel.Address,
                Email = employeeRequestModel.Email
            };
            if (hasId)
            {
                employee.Id = employeeRequestModel.Id;
            }
            return employee;
        }




        public static EmployeeRoleResponseModel ToEmployeeRoleResponseModel(this EmployeeRole employeeRole)
        {
            return new EmployeeRoleResponseModel
            {
                Id = employeeRole.Id,
                EmployeeRoleName = employeeRole.EmployeeRoleName,
                ABBR = employeeRole.ABBR
            };
        }

        public static EmployeeRole ToEmployeeRole(this EmployeeRoleRequestModel employeeRoleRequestModel, bool hasId)
        {
            var employeeRole = new EmployeeRole()
            {
                EmployeeRoleName = employeeRoleRequestModel.EmployeeRoleName,
                ABBR = employeeRoleRequestModel.ABBR
            };
            if (hasId)
            {
                employeeRole.Id = employeeRoleRequestModel.Id;
            }
            return employeeRole;
        }
	}
}

