using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Entities;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repository
{
	public class EmployeeStatusRepositoryAsync : BaseRepositoryAsync<EmployeeStatus>, IEmployeeStatusRepositoryAsync
	{
		public EmployeeStatusRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
	}
}

