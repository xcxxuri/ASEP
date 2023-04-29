using System;
using Authentication.ApplicationCore.Models;

namespace Authentication.ApplicationCore.Contract.Services
{
	public interface IRoleServiceAsync
	{
        Task<IEnumerable<RoleResponseModel>> GetAllRoleAsync();
        Task<RoleResponseModel> GetRoleByIdAsync(int id);
        Task<int> AddRoleAsync(RoleRequestModel role);
        Task<int> UpdateRoleAsync(RoleRequestModel role);
        Task<int> DeleteRoleAsync(int id);
	}
}

