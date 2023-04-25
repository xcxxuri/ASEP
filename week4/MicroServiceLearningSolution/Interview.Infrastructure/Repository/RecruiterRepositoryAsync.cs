using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
	public class RecruiterRepositoryAsync : BaseRepositoryAsync<Recruiter>, IRecruiterRepositoryAsync
	{
		public RecruiterRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
		{
		}
	}
}

