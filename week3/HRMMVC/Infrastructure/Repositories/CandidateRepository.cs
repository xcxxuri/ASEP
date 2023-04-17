using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate> ,ICandidateRepository
    {
        // here we use : base to call the constructor of the base class
        public CandidateRepository(RecurtingDbContext dbContext) : base(dbContext)
        {
            // we dont need to write any code here because we are calling the constructor of the base class
        }
        
    }
}

