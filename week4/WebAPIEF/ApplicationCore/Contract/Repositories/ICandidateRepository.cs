using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Contract.Repositories
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<Candidate> GetUserByEmail(string email);
        Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where,
          params Expression<Func<Candidate, object>>[] includes);
    }
}

