using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Contract.Services;
using Interview.ApplicationCore.Entities;
using Interview.ApplicationCore.Models;
using Interview.Infrastructure.Helper;

namespace Interview.Infrastructure.Service
{
	public class InterviewFeedbackServiceAsync: IInterviewFeedbackServiceAsync
	{
        private readonly IInterviewFeedbackRepositoryAsync _interviewFeedbackRepositoryAsync;
		public InterviewFeedbackServiceAsync(IInterviewFeedbackRepositoryAsync interviewFeedbackRepositoryAsync)
        {
            _interviewFeedbackRepositoryAsync = interviewFeedbackRepositoryAsync;
        }

        public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllInterviewFeedbackAsync()
        {
            var interviewFeedback = await _interviewFeedbackRepositoryAsync.GetAllAsync();
            var response = interviewFeedback.Select(x => x.ToInterviewFeedbackResponseModel());
            return response;
        }

        public async Task<InterviewFeedbackResponseModel> GetInterviewFeedbackByIdAsync(int id)
        {
            var interviewFeedback = await _interviewFeedbackRepositoryAsync.GetByIdAsync(id);
            var response = interviewFeedback.ToInterviewFeedbackResponseModel();
            return response;
        }


        public async Task<int> AddInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            var existingInterviewFeedback = await _interviewFeedbackRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviewFeedback != null)
            {
                throw new Exception("Id is already used");
            }
            InterviewFeedback interviewFeedback = new InterviewFeedback();
            if (model != null)
            {
                interviewFeedback = model.ToInterviewFeedback(false);
            }
            return await _interviewFeedbackRepositoryAsync.InsertAsync(interviewFeedback);
        }

        public async Task<int> UpdateInterviewFeedbackAsync(InterviewFeedbackRequestModel model)
        {
            var existingInterviewFeedback = await _interviewFeedbackRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviewFeedback == null)
            {
                throw new Exception("InterviewFeedback does not exist");
            }
            if (model != null)
            {
                InterviewFeedback interviewFeedback = model.ToInterviewFeedback(true);
                return await _interviewFeedbackRepositoryAsync.UpdateAsync(interviewFeedback);
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> DeleteInterviewFeedbackAsync(int id)
        {
            var existingInterviewFeedback = await _interviewFeedbackRepositoryAsync.GetByIdAsync(id);
            if (existingInterviewFeedback == null)
            {
                throw new Exception("InterviewFeedback does not exist");
            }
            return await _interviewFeedbackRepositoryAsync.DeleteAsync(id);
        }
	}
}

