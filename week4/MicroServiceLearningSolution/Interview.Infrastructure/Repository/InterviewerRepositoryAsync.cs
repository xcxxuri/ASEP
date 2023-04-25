using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
	public class InterviewerRepositoryAsync : BaseRepositoryAsync<Interviewer>, IInterviewerRepositoryAsync
	{
		public InterviewerRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
        {
        }
	}
}

