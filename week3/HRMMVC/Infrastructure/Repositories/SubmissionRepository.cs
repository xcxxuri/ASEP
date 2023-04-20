using System;
using System.Linq.Expressions;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class SubmissionRepository : BaseRepository<Submission>, ISubmissionRepository
	{
		public SubmissionRepository(RecurtingDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where, params Expression<Func<Submission, object>>[] includes)
        {
            var query = _ReDbContext.Set<Submission>().AsQueryable();

            if (includes != null)
            {
                foreach (var navigationProperty in includes)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return await query.FirstOrDefaultAsync(where);
            
        }
    }
}

