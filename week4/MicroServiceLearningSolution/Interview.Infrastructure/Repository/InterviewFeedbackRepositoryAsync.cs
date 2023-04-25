using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
	public class InterviewFeedbackRepositoryAsync: BaseRepositoryAsync<InterviewFeedback>, IInterviewFeedbackRepositoryAsync
	{
		public InterviewFeedbackRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
		{
		}
	}
}

