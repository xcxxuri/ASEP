using System;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Entities;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository
{
	public class JobRequirementRepositoryAsync : BaseRepositoryAsync<JobRequirement>, IJobRequirementRepositoryAsync
	{
		public JobRequirementRepositoryAsync(RecruitingDbContext dbContext) : base(dbContext)
        {
        }
	}
}

