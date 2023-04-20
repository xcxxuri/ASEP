using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecurtingDbContext dbContext) : base(dbContext)
        {
        }


    }
}

