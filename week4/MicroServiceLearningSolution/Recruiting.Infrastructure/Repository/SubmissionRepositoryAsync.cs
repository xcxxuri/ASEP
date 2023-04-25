using System;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Entities;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository
{
	public class SubmissionRepositoryAsync : BaseRepositoryAsync<Submission>, ISubmissionRepositoryAsync
	{
		public SubmissionRepositoryAsync(RecruitingDbContext dbContext) : base(dbContext)
        {
        }
	}
}

