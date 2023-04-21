using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Contract.Repositories
{
    public interface ISubmissionRepository : IBaseRepository<Submission>
    {
        //public Task<Submission> GetSubmissionsByJobAndCandidateIdAsync(int jobReqId, int candidateId);
        public Task<Submission> FirstOrDefaultWithIncludesAsync(Expression<Func<Submission, bool>> where,
            params Expression<Func<Submission, object>>[] includes);
    }
}

