using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Contract.Services;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models;
using Authentication.Infrastructure.Helper;

namespace Authentication.Infrastructure.Service
{
	public class UserRoleServiceAsync : IUserRoleServiceAsync
	{
        private readonly IUserRoleRepositoryAsync _userRoleRepositoryAsync;
		public UserRoleServiceAsync(IUserRoleRepositoryAsync userRoleRepositoryAsync)
        {
            _userRoleRepositoryAsync = userRoleRepositoryAsync;
        }
       
        public async Task<int> AddUserRoleAsync(UserRoleRequestModel model)
        {
            UserRole userRole = new UserRole();
            if (model != null)
            {
                userRole = model.ToUserRole(false);
            }
            return await _userRoleRepositoryAsync.InsertAsync(userRole);
        }

        public async Task<int> DeleteUserRoleAsync(int id)
        {
            var existingUserRole = await _userRoleRepositoryAsync.GetByIdAsync(id);
            if (existingUserRole == null)
            {
                throw new Exception("UserRole does not exist");
            }
            return await _userRoleRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserRoleResponseModel>> GetAllUserRoleAsync()
        {
            var userRoles = await _userRoleRepositoryAsync.GetAllAsync();
            var response = userRoles.Select(x => x.ToUserRoleResponseModel());
            return response;
        }

        public async Task<UserRoleResponseModel> GetUserRoleByIdAsync(int id)
        {
            var userRole = await _userRoleRepositoryAsync.GetByIdAsync(id);
            var response = userRole.ToUserRoleResponseModel();
            return response;
        }

        public async Task<int> UpdateUserRoleAsync(UserRoleRequestModel model)
        {
            var existingUserRole = await _userRoleRepositoryAsync.GetByIdAsync(model.Id);
            if (existingUserRole == null)
            {
                throw new Exception("UserRole does not exist");
            }
            if (model != null)
            {
                UserRole userRole = model.ToUserRole(true);
                return await _userRoleRepositoryAsync.UpdateAsync(userRole);
            }
            return 0;
        }
        
	}
}

