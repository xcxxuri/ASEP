using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Infrastructure.Helper;
using Infrastructure.Repositories;

namespace Infrastructure.Service
{
    public class JobRequirementService : IJobRequirementService
    {
        IJobRequirementRepository _jobRequirementRepository;

        public JobRequirementService(IJobRequirementRepository jobRequirementRepository)
        {
            _jobRequirementRepository = jobRequirementRepository;
        }

        public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement();
            if (model != null)
            {
                jobRequirement.NumberOfPosition = model.NumberOfPosition;
                jobRequirement.Title = model.Title;
                jobRequirement.Description = model.Description;
                jobRequirement.HiringManagerId = model.HiringManagerId;
                jobRequirement.StartDate = model.StartDate;
                jobRequirement.IsActive = model.IsActive;
                jobRequirement.ClosedOn = model.ClosedOn;
                jobRequirement.ClosedReason = model.ClosedReason;
                jobRequirement.CreatedOn = model.CreatedOn;
                //jobRequirement.JobCategory = new JobCategory();
                jobRequirement.Submissions = new List<Submission>();
                jobRequirement.EmployeeRequirementTypes = new List<EmployeeRequirementType>();
            }
            return await _jobRequirementRepository.InsertAsync(jobRequirement);
        }

        public async Task<int> DeleteJobRequirementAsync(int id)
        {
            return await _jobRequirementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements()
        {
            var jobRequirements = await _jobRequirementRepository.GetAllAsync();
            var response = jobRequirements.Select(x => x.ToJobRequirementResponseModel());
            return response;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var jobRequirement = await _jobRequirementRepository.GetByIdAsync(id);
            if (jobRequirement == null)
            {
                throw new NotFoundException("Job Requirement not found", id);
            }
            else
            {
                return jobRequirement.ToJobRequirementResponseModel();
            }
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            var existingJobRequirement = await _jobRequirementRepository.GetJobRequirementsIncludingCategory(x => model.Id == x.Id);
            if (existingJobRequirement == null)
            {
                throw new NotFoundException("Job Requirement not found", model.Id);
            }
            JobRequirement jobRequirement = new JobRequirement();
            if (model != null)
            {
                jobRequirement.NumberOfPosition = model.NumberOfPosition;
                jobRequirement.Title = model.Title;
                jobRequirement.Description = model.Description;
                jobRequirement.HiringManagerId = model.HiringManagerId;
                jobRequirement.StartDate = model.StartDate;
                jobRequirement.IsActive = model.IsActive;
                jobRequirement.ClosedOn = model.ClosedOn;
                jobRequirement.ClosedReason = model.ClosedReason;
                jobRequirement.CreatedOn = model.CreatedOn;
                jobRequirement.JobCategory = model.JobCategory;
                return await _jobRequirementRepository.UpdateAsync(jobRequirement);
            }
            else
            {
                return -1;
            }

        }
    }
}

