using System;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Contract.Services
{
    public interface ISubmissionServiceAsync
    {
        Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync();
        Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id);
        Task<int> AddSubmissionAsync(SubmissionRequestModel candidate);
        Task<int> UpdateSubmissionAsync(SubmissionRequestModel candidate);
        Task<int> DeleteSubmissionAsync(int id);
    }
}

