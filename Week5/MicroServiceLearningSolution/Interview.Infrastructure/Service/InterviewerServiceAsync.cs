using System;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Contract.Services;
using Interview.ApplicationCore.Entities;
using Interview.ApplicationCore.Models;
using Interview.Infrastructure.Helper;

namespace Interview.Infrastructure.Service
{
    public class InterviewerServiceAsync : IInterviewerServiceAsync
    {
        private readonly IInterviewerRepositoryAsync _interviewerRepositoryAsync;
        public InterviewerServiceAsync(IInterviewerRepositoryAsync interviewerRepositoryAsync)
        {
            _interviewerRepositoryAsync = interviewerRepositoryAsync;
        }

        public async Task<IEnumerable<InterviewerResponseModel>> GetAllInterviewerAsync()
        {
            var interviewer = await _interviewerRepositoryAsync.GetAllAsync();
            var response = interviewer.Select(x => x.ToInterviewerResponseModel());
            return response;
        }

        public async Task<InterviewerResponseModel> GetInterviewerByIdAsync(int id)
        {
            var interviewer = await _interviewerRepositoryAsync.GetByIdAsync(id);
            var response = interviewer.ToInterviewerResponseModel();
            return response;
        }


        public async Task<int> AddInterviewerAsync(InterviewerRequestModel model)
        {
            var existingInterviewer = await _interviewerRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviewer != null)
            {
                throw new Exception("Id is already used");
            }
            Interviewer interviewer = new Interviewer();
            if (model != null)
            {
                interviewer = model.ToInterviewer(false);
            }
            return await _interviewerRepositoryAsync.InsertAsync(interviewer);
        }

        public async Task<int> UpdateInterviewerAsync(InterviewerRequestModel model)
        {
            var existingInterviewer = await _interviewerRepositoryAsync.GetByIdAsync(model.Id);
            if (existingInterviewer == null)
            {
                throw new Exception("Interviewer does not exist");
            }
            if (model != null)
            {
                Interviewer interviewer = model.ToInterviewer(true);
                return await _interviewerRepositoryAsync.UpdateAsync(interviewer);
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> DeleteInterviewerAsync(int Id)
        {
            var existingInterviewer = await _interviewerRepositoryAsync.GetByIdAsync(Id);
            if (existingInterviewer == null)
            {
                throw new Exception("Interviewer does not exist");
            }
            return await _interviewerRepositoryAsync.DeleteAsync(Id);
        }

    }
}

