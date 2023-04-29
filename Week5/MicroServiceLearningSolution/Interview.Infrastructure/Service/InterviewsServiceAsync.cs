using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Contract.Services;
using Interview.ApplicationCore.Entities;
using Interview.ApplicationCore.Models;
using Interview.Infrastructure.Helper;

namespace Interview.Infrastructure.Service
{
	public class InterviewsServiceAsync : IInterviewsServiceAsync
	{
        private readonly IInterviewsRepositoryAsync _interviewsRepositoryAsync;
        public InterviewsServiceAsync(IInterviewsRepositoryAsync interviewsRepositoryAsync)
        {
            _interviewsRepositoryAsync = interviewsRepositoryAsync;
        }
        
        public async Task<IEnumerable<InterviewsResponseModel>> GetAllInterviewsAsync()
        {
            var interviews = await _interviewsRepositoryAsync.GetAllAsync();
            var response = interviews.Select(x => x.ToInterviewsResponseModel());
            return response;
        }

        public async Task<InterviewsResponseModel> GetInterviewsByIdAsync(int id)
        {
            var interviews = await _interviewsRepositoryAsync.GetByIdAsync(id);
            var response = interviews.ToInterviewsResponseModel();
            return response;
        }


        public async Task<int> AddInterviewsAsync(InterviewsRequestModel model)
        {
            var existingInterviews = await _interviewsRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviews != null)
            {
                throw new Exception("Id is already used");
            }
            Interviews interviews = new Interviews();
            if (model != null)
            {
                interviews = model.ToInterviews(false);
            }
            return await _interviewsRepositoryAsync.InsertAsync(interviews);
        }


        public async Task<int> UpdateInterviewsAsync(InterviewsRequestModel model)
        {
            var existingInterviews = await _interviewsRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviews == null)
            {
                throw new Exception("Interviews does not exist");
            }
            if (model != null)
            {
                Interviews interviews = model.ToInterviews(true);
                return await _interviewsRepositoryAsync.UpdateAsync(interviews);
            }
            else
            {
                throw new Exception("Interviews does not exist");
            }
        }

        public async Task<int> DeleteInterviewsAsync(int id)
        {
            var existingInterviews = await _interviewsRepositoryAsync.GetByIdAsync(id);
            if (existingInterviews == null)
            {
                throw new Exception("Interviews does not exist");
            }
            return await _interviewsRepositoryAsync.DeleteAsync(id);
        }

        // schdule interview for candidate
        // public async Task<int> ScheduleInterviewsAsync(CandidateRequestModel model)
        // {
        //     var existingInterviews = await _interviewsRepositoryAsync.GetByIdAsync(model.Id);
        //     if (existingInterviews != null)
        //     {
        //         throw new Exception("Id is already used");
        //     }
        //     Interviews interviews = new Interviews();
        //     if (model != null)
        //     {
        //         interviews = model.ToInterviews(false);
        //     }
        //     return await _interviewsRepositoryAsync.InsertAsync(interviews);
        // }

	}
}

