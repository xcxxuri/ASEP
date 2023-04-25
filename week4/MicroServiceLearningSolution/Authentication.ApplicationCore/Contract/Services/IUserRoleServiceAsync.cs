using System;
using Authentication.ApplicationCore.Models;

namespace Authentication.ApplicationCore.Contract.Services
{
    public interface IUserRoleServiceAsync
    {
        Task<IEnumerable<UserRoleResponseModel>> GetAllUserRoleAsync();
        Task<UserRoleResponseModel> GetUserRoleByIdAsync(int id);
        Task<int> AddUserRoleAsync(UserRoleRequestModel userrole);
        Task<int> UpdateUserRoleAsync(UserRoleRequestModel userrole);
        Task<int> DeleteUserRoleAsync(int id);

    }
}

