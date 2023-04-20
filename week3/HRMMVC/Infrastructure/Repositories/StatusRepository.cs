using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class StatusRepository : BaseRepository<Status>, IStatusRepository
	{
		public StatusRepository(RecurtingDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<IEnumerable<Status>> GetStatusByState(string state)
        {
            var statuses = await _ReDbContext.Statuses.Where(s => s.State == state).Include(s => s.Submission).ToListAsync();
            return statuses;
        }
    }
}

