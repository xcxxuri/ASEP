using System;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Entities;
using Recruiting.Infrastructure.Data;

namespace Recruiting.Infrastructure.Repository
{
    public class CandidateRepositoryAsync : BaseRepositoryAsync<Candidate>, ICandidateRepositoryAsync
    {
        public CandidateRepositoryAsync(RecruitingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Candidate> GetUserByEmail(string email)
        {
            return await DbContext.Candidates.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}

