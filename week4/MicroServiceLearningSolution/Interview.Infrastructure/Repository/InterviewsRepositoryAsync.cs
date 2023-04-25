using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
	public class InterviewsRepositoryAsync : BaseRepositoryAsync<Interviews>, IInterviewsRepositoryAsync
	{
		public InterviewsRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
		{
		}
	}
}

