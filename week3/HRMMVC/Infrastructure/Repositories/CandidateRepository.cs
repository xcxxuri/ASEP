﻿using System;
using System.Linq.Expressions;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate> ,ICandidateRepository
    {
        // here we use : base to call the constructor of the base class
        public CandidateRepository(RecurtingDbContext dbContext) : base(dbContext)
        {
            // we dont need to write any code here because we are calling the constructor of the base class
        }

        public async Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where, params Expression<Func<Candidate, object>>[] includes)
        {
            var query = _ReDbContext.Candidates.AsQueryable();

            if(includes != null)
            {
                foreach (var navigationProperty in includes)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return await query.FirstOrDefaultAsync(where);
            
        }

        public async Task<Candidate> GetCandidateByEmail(string email)
        {
            return await _ReDbContext.Candidates.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}

