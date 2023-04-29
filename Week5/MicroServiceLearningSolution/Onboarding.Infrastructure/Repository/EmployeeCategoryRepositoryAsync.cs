using System;
using Onboarding.ApplicationCore.Contract.Repositories;
using Onboarding.ApplicationCore.Entities;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repository
{
	public class EmployeeCategoryRepositoryAsync :BaseRepositoryAsync<EmployeeCategory>, IEmployeeCategoryRepositoryAsync
	{
		public EmployeeCategoryRepositoryAsync(OnboardingDbContext dbContext) : base(dbContext)
        {
        }
	}
}

