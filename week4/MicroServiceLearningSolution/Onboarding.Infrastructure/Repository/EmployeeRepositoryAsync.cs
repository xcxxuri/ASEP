using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Entities;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repository
{
	public class EmployeeRepositoryAsync : BaseRepositoryAsync<Employee>, IEmployeeRepositoryAsync
	{
		public EmployeeRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
	}
}

