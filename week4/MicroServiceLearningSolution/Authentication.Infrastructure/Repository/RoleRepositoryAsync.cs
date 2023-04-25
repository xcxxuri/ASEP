using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Entities;
using Authentication.Infrastructure.Data;

namespace Authentication.Infrastructure.Repository
{
	public class RoleRepositoryAsync: BaseRepositoryAsync<Role>, IRoleRepositoryAsync
	{
		public RoleRepositoryAsync(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }
	}
}

