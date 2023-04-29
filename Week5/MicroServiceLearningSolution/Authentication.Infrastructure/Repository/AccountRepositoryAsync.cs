using System;
using Authentication.ApplicationCore.Contract.Repositories;
using Authentication.ApplicationCore.Entities;
using Authentication.Infrastructure.Data;

namespace Authentication.Infrastructure.Repository
{
	public class AccountRepositoryAsync: BaseRepositoryAsync<Account>, IAccountRepositoryAsync
	{
        public AccountRepositoryAsync(AuthenticationDbContext dbContext) : base(dbContext)
        {
        }
	}
}

