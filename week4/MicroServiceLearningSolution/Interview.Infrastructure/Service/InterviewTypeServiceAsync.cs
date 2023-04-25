using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Contract.Services;
using Interview.ApplicationCore.Entities;
using Interview.ApplicationCore.Models;
using Interview.Infrastructure.Helper;

namespace Interview.Infrastructure.Service
{
	public class InterviewTypeServiceAsync: IInterviewTypeServiceAsync
	{
        private readonly IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync;
        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync)
        {
            _interviewTypeRepositoryAsync = interviewTypeRepositoryAsync;
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllInterviewTypeAsync()
        {
            var interviewType = await _interviewTypeRepositoryAsync.GetAllAsync();
            var response = interviewType.Select(x => x.ToInterviewTypeResponseModel());
            return response;
        }

        public async Task<InterviewTypeResponseModel> GetInterviewTypeByIdAsync(int id)
        {
            var interviewType = await _interviewTypeRepositoryAsync.GetByIdAsync(id);
            var response = interviewType.ToInterviewTypeResponseModel();
            return response;
        }

        
        public async Task<int> AddInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var existingInterviewType = await _interviewTypeRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviewType != null)
            {
                throw new Exception("Id is already used");
            }
            InterviewType interviewType = new InterviewType();
            if (model != null)
            {
                interviewType = model.ToInterviewType(false);
            }
            return await _interviewTypeRepositoryAsync.InsertAsync(interviewType);
        }

        public async Task<int> UpdateInterviewTypeAsync(InterviewTypeRequestModel model)
        {
            var existingInterviewType = await _interviewTypeRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviewType == null)
            {
                throw new Exception("InterviewType does not exist");
            }
            if (model != null)
            {
                InterviewType interviewType = model.ToInterviewType(true);
                return await _interviewTypeRepositoryAsync.UpdateAsync(interviewType);
            }
            else
            {
                throw new Exception("InterviewType does not exist");
            }
        }

        public async Task<int> DeleteInterviewTypeAsync(int id)
        {
            var existingInterviewType = await _interviewTypeRepositoryAsync.GetByIdAsync(id);
            if (existingInterviewType == null)
            {
                throw new Exception("InterviewType does not exist");
            }
            return await _interviewTypeRepositoryAsync.DeleteAsync(id);
        }


	}
}

