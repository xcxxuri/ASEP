using System;
using Interview.ApplicationCore.Models;

namespace Interview.ApplicationCore.Contract.Services
{
    public interface IInterviewsServiceAsync
    {
        Task<IEnumerable<InterviewsResponseModel>> GetAllInterviewsAsync();
        Task<InterviewsResponseModel> GetInterviewsByIdAsync(int id);
        Task<int> AddInterviewsAsync(InterviewsRequestModel interviews);
        Task<int> UpdateInterviewsAsync(InterviewsRequestModel interviews);
        Task<int> DeleteInterviewsAsync(int id);
        // Task<int> ScheduleInterviewsAsync(InterviewsRequestModel model);


    }
}

