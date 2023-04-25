using System;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helper;

namespace Recruiting.Infrastructure.Service
{
    public class JobRequirementServiceAsync : IJobRequirementServiceAsync
    {
        private readonly IJobRequirementRepositoryAsync _jobRequirementRepositoryAsync;
        public JobRequirementServiceAsync(IJobRequirementRepositoryAsync jobRequirementRepositoryAsync)
        {
            _jobRequirementRepositoryAsync = jobRequirementRepositoryAsync;
        }

        public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel JRmodel)
        {
            // var existJobRequirement = await _jobRequirementRepositoryAsync.GetJobRequirementByIdAsync(JRmodel.JobId);
            var existingJR = await _jobRequirementRepositoryAsync.GetByIdAsync(JRmodel.Id);
            if (existingJR != null)
            {
                throw new Exception("Id is already existed");
            }
            JobRequirement jr = new JobRequirement();
            if (JRmodel != null)
            {
                jr = JRmodel.ToJobRequirement(false);
            }
            return await _jobRequirementRepositoryAsync.InsertAsync(jr);

        }

        public async Task<int> DeleteJobRequirementAsync(int id)
        {
            var existingJR = await _jobRequirementRepositoryAsync.GetByIdAsync(id);
            if (existingJR == null)
            {
                throw new Exception("Job Requirement does not exist");
            }
            return await _jobRequirementRepositoryAsync.DeleteAsync(id);
            
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementAsync()
        {
            var jobRequirements = await _jobRequirementRepositoryAsync.GetAllAsync();
            var response = jobRequirements.Select(x => x.ToJobRequirementResponseModel());
            return response;

        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var jobRequirement = await _jobRequirementRepositoryAsync.GetByIdAsync(id);
            var response = jobRequirement.ToJobRequirementResponseModel();
            return response;
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel JRmodel)
        {
            var existingJR = await _jobRequirementRepositoryAsync.GetByIdAsync(JRmodel.Id);
            if (existingJR == null)
            {
                throw new Exception("Job Requirement does not exist");
            }
            if (JRmodel != null)
            {
                JobRequirement jr = JRmodel.ToJobRequirement(true);
                return await _jobRequirementRepositoryAsync.UpdateAsync(jr);
            }
            return 0;
        }
    }
}

