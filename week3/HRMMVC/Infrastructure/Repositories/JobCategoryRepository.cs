using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class JobCategoryRepository: BaseRepository<JobCategory>, IJobCategoryRepository
	{
		public JobCategoryRepository(RecurtingDbContext dbContext) : base(dbContext)
		{
		}
	}
}

