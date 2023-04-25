using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
	public class InterviewTypeRepositoryAsync : BaseRepositoryAsync<InterviewType>, IInterviewTypeRepositoryAsync
	{
		public InterviewTypeRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
		{
		}
	}
}

