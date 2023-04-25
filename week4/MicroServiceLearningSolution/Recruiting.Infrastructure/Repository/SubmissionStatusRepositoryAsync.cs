using System;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Entities;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository
{
	public class SubmissionStatusRepositoryAsync: BaseRepositoryAsync<SubmissionStatus>, ISubmissionStatusRepositoryAsync
	{
		public SubmissionStatusRepositoryAsync(RecruitingDbContext dbContext) : base(dbContext)
        {
        }
	}
}

