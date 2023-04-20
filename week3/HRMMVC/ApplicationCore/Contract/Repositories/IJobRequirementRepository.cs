using System;
using System.Linq.Expressions;
using ApplicationCore.Entities;

namespace ApplicationCore.Contract.Repositories
{
    public interface IJobRequirementRepository : IBaseRepository<JobRequirement>
    {
        public Task<IEnumerable<JobRequirement>> GetJobRequirementsIncludingCategory(Expression<Func<JobRequirement, bool>> filter);
    }
}

