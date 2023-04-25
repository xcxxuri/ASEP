using System;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models;

namespace Authentication.Infrastructure.Helper
{
    public static class ModelMapper
    {
        public static AccountResponseModel ToAccountResponseModel(this Account account)
        {
            return new AccountResponseModel
            {
                Id = account.Id,
                EmployeeId = account.EmployeeId,
                Email = account.Email,
                RoleId = account.RoleId,
                FirstName = account.FirstName,
                LastName = account.LastName,
                HashPassword = account.HashPassword,
                Salt = account.Salt
            };
        }

        public static Account ToAccount(this AccountRequestModel accountRequestModel, bool hasId)
        {
            var account = new Account()
            {
                EmployeeId = accountRequestModel.EmployeeId,
                Email = accountRequestModel.Email,
                RoleId = accountRequestModel.RoleId,
                FirstName = accountRequestModel.FirstName,
                LastName = accountRequestModel.LastName,
                HashPassword = accountRequestModel.HashPassword,
                Salt = accountRequestModel.Salt
            };
            if (hasId)
            {
                account.Id = accountRequestModel.Id;
            }
            return account;
        }

        public static RoleResponseModel ToRoleResponseModel(this Role role)
        {
            return new RoleResponseModel
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
        }

        public static Role ToRole(this RoleRequestModel roleRequestModel, bool hasId)
        {
            var role = new Role()
            {
                Name = roleRequestModel.Name,
                Description = roleRequestModel.Description
            };
            if (hasId)
            {
                role.Id = roleRequestModel.Id;
            }
            return role;
        }

        public static UserRoleResponseModel ToUserRoleResponseModel(this UserRole userRole)
        {
            return new UserRoleResponseModel
            {
                Id = userRole.Id,
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            };
        }

        public static UserRole ToUserRole(this UserRoleRequestModel userRoleRequestModel, bool hasId)
        {
            var userRole = new UserRole()
            {
                UserId = userRoleRequestModel.UserId,
                RoleId = userRoleRequestModel.RoleId
            };
            if (hasId)
            {
                userRole.Id = userRoleRequestModel.Id;
            }
            return userRole;
        }     

    }
}

