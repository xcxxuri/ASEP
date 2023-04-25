using System;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helper;

namespace Recruiting.Infrastructure.Service
{
    public class SubmissionServiceAsync : ISubmissionServiceAsync
    {
        private readonly ISubmissionRepositoryAsync _submissionRepositoryAsync;
        public SubmissionServiceAsync(ISubmissionRepositoryAsync submissionRepositoryAsync)
        {
            _submissionRepositoryAsync = submissionRepositoryAsync;
        }

        public async Task<int> AddSubmissionAsync(SubmissionRequestModel submissionmodel)
        {
            var existingSubmission = await _submissionRepositoryAsync.GetByIdAsync(submissionmodel.Id);
            if (existingSubmission != null)
            {
                throw new Exception("Id is already existed");
            }
            Submission submission = new Submission();
            if (submissionmodel != null)
            {
                submission = submissionmodel.ToSubmission(false);
            }
            return await _submissionRepositoryAsync.InsertAsync(submission);
        }

        public async Task<int> DeleteSubmissionAsync(int id)
        {
            var existingSubmission = await _submissionRepositoryAsync.GetByIdAsync(id);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            return await _submissionRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync()
        {
            var submissions = await _submissionRepositoryAsync.GetAllAsync();
            var response = submissions.Select(x => x.ToSubmissionResponseModel());
            return response;
        }

        public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
        {
            var submission = await _submissionRepositoryAsync.GetByIdAsync(id);
            var response = submission.ToSubmissionResponseModel();
            return response;
        }

        public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel submissionmodel)
        {
            var existingSubmission = await _submissionRepositoryAsync.GetByIdAsync(submissionmodel.Id);
            if (existingSubmission == null)
            {
                throw new Exception("Submission does not exist");
            }
            if (submissionmodel != null)
            {
                Submission submission = submissionmodel.ToSubmission(true);
                return await _submissionRepositoryAsync.UpdateAsync(submission);
            }
            return 0;
        }
    }
}

