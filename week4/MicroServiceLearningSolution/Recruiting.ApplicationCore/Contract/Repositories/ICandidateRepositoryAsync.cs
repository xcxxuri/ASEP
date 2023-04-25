using System;
using Recruiting.ApplicationCore.Entities;

namespace Recruiting.ApplicationCore.Contract.Repositories
{
    public interface ICandidateRepositoryAsync : IBaseRepositoryAsync<Candidate>
    {
        Task<Candidate> GetUserByEmail(string email);
    }
}

