using System;
using Interview.ApplicationCore.Models;

namespace Interview.ApplicationCore.Contract.Services
{
	public interface IInterviewTypeServiceAsync
	{
        
        Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypeAsync();
        Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id);
        Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel interviewType);
        Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel interviewType);
        Task<int> DeleteInterviewTypeAsync(int id);



        

	}
}

