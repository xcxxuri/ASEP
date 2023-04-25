using System;
using Interview.ApplicationCore.Models;

namespace Interview.ApplicationCore.Contract.Services
{
    public interface IInterviewerServiceAsync
    {
        Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewerAsync();
        Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id);
        Task<int> AddInterviewerAsync(InterviewerRequestModel interviewer);
        Task<int> UpdateInterviewerAsync(InterviewerRequestModel interviewer);
        Task<int> DeleteInterviewerAsync(int id);

    }
}

