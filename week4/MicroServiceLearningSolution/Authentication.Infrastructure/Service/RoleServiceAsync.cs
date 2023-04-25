using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Contract.Services;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models;
using Authentication.Infrastructure.Helper;

namespace Authentication.Infrastructure.Service
{
    public class RoleServiceAsync : IRoleServiceAsync
    {
        private readonly IRoleRepositoryAsync _roleRepositoryAsync;
        public RoleServiceAsync(IRoleRepositoryAsync roleRepositoryAsync)
        {
            _roleRepositoryAsync = roleRepositoryAsync;
        }

        public async Task<IEnumerable<RoleResponseModel>> GetAllRoleAsync()
        {
            var roles = await _roleRepositoryAsync.GetAllAsync();
            var response = roles.Select(x => x.ToRoleResponseModel());
            return response;
        }

        public async Task<RoleResponseModel> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepositoryAsync.GetByIdAsync(id);
            var response = role.ToRoleResponseModel();
            return response;
        }

        public async Task<int> AddRoleAsync(RoleRequestModel model)
        {
            var existingRole = await _roleRepositoryAsync.GetByIdAsync(model.Id);
            if (existingRole != null)
            {
                throw new Exception("Id is already used");
            }
            Role role = new Role();
            if (model != null)
            {
                role = model.ToRole(false);
            }
            return await _roleRepositoryAsync.InsertAsync(role);
        }

        public async Task<int> UpdateRoleAsync(RoleRequestModel model)
        {
            var existingRole = await _roleRepositoryAsync.GetByIdAsync(model.Id);
            if (existingRole == null)
            {
                throw new Exception("Role does not exist");
            }
            if (model != null)
            {
                Role role = model.ToRole(true);
                return await _roleRepositoryAsync.UpdateAsync(role);
            }
            return 0;
        }

        public async Task<int> DeleteRoleAsync(int id)
        {
            var existingRole = await _roleRepositoryAsync.GetByIdAsync(id);
            if (existingRole == null)
            {
                throw new Exception("Role does not exist");
            }
            return await _roleRepositoryAsync.DeleteAsync(id);
        }

    }
}

