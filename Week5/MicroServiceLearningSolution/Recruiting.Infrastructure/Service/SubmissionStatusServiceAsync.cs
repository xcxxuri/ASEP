using System;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helper;

namespace Recruiting.Infrastructure.Service
{
    public class SubmissionStatusServiceAsync : ISubmissionStatusServiceAsync
    {
        private readonly ISubmissionStatusRepositoryAsync _submissionStatusRepositoryAsync;
        public SubmissionStatusServiceAsync(ISubmissionStatusRepositoryAsync submissionStatusRepositoryAsync)
        {
            _submissionStatusRepositoryAsync = submissionStatusRepositoryAsync;
        }

        public async Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            var existingSubmissionStatus = await _submissionStatusRepositoryAsync.GetByIdAsync(model.Id);
            if (existingSubmissionStatus != null)
            {
                throw new Exception("Id is already existed");
            }
            SubmissionStatus submissionStatus = new SubmissionStatus();
            if (model != null)
            {
                submissionStatus = model.ToSubmissionStatus(false);
            }
            return await _submissionStatusRepositoryAsync.InsertAsync(submissionStatus);

        }

        public async Task<int> DeleteSubmissionStatusAsync(int id)
        {
            var existingSubmissionStatus = await _submissionStatusRepositoryAsync.GetByIdAsync(id);
            if (existingSubmissionStatus == null)
            {
                throw new Exception("Submission Status does not exist");
            }
            return await _submissionStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatusAsync()
        {
            var submissionStatus = await _submissionStatusRepositoryAsync.GetAllAsync();
            var response = submissionStatus.Select(x => x.ToSubmissionStatusResponseModel());
            return response;
        }

        public async Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id)
        {
            var submissionStatus = await _submissionStatusRepositoryAsync.GetByIdAsync(id);
            var response = submissionStatus.ToSubmissionStatusResponseModel();
            return response;
        }

        public async Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel model)
        {
            var existingSubmissionStatus = await _submissionStatusRepositoryAsync.GetByIdAsync(model.Id);
            if (existingSubmissionStatus == null)
            {
                throw new Exception("Submission Status does not exist");
            }
            if (model != null)
            {
                SubmissionStatus submissionStatus = model.ToSubmissionStatus(true);
                return await _submissionStatusRepositoryAsync.UpdateAsync(submissionStatus);
            }
            return 0;

        }
    }
}

