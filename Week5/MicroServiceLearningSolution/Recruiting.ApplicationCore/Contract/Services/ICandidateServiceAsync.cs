using System;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Contract.Services
{
    public interface ICandidateServiceAsync
    {
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidateAsync();
        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
        Task<int> AddCandidateAsync(CandidateRequestModel candidate);
        Task<int> UpdateCandidateAsync(CandidateRequestModel candidate);
        Task<int> DeleteCandidateAsync(int id);

    }
}

