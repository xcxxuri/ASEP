using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Entities;
using Authentication.Infrastructure.Data;

namespace Authentication.Infrastructure.Repository
{
	public class UserRoleRepositoryAsync: BaseRepositoryAsync<UserRole>, IUserRoleRepositoryAsync
	{
		public UserRoleRepositoryAsync(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }
	}
}

