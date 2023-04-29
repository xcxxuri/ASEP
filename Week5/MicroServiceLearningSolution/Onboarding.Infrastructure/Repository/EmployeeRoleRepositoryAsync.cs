using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Entities;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repository
{
	public class EmployeeRoleRepositoryAsync: BaseRepositoryAsync<EmployeeRole>, IEmployeeRoleRepositoryAsync
	{
		public EmployeeRoleRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
	}
}

