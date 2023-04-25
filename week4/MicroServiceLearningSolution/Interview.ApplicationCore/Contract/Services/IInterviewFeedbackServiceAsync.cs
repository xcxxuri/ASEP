using System;
using Interview.ApplicationCore.Models;

namespace Interview.ApplicationCore.Contract.Services
{
    public interface IInterviewFeedbackServiceAsync
    {
        Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbackAsync();
        Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id);
        Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel interviewFeedback);
        Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel interviewFeedback);
        Task<int> DeleteInterviewFeedbackAsync(int id);

    }
}

