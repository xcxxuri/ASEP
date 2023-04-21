﻿using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Infrastructure.Helper;

namespace Infrastructure.Services
{
	public class JobRequirementService : IJobRequirementService
	{
		IJobRequirementRepository jobRequirementRepository;
        public JobRequirementService(IJobRequirementRepository _jr)
        {
            jobRequirementRepository = _jr;
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
            //returns number of rows affected, typically 1
                return await jobRequirementRepository.InsertAsync(jobRequirement);
        }

        public async Task<int> DeleteJobRequirementAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await jobRequirementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements()
        {
            var jRTypes = await jobRequirementRepository.GetAllAsync();
            var response = jRTypes.Select(x => x.ToJobRequirementResponseModel());
            return response;
        }
        public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
        {
            var jR = await jobRequirementRepository.GetByIdAsync(id);
            if (jR != null)
            {
                var response = jR.ToJobRequirementResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("JobRequirement", id);
            }
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            var existingJobRequirement = await jobRequirementRepository
                .GetJobRequirementsIncludingCategory(x => model.Id == x.Id);
            if (existingJobRequirement == null)
            {
                throw new Exception("JobRequirement does not exist");
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
                return await jobRequirementRepository.UpdateAsync(jobRequirement);
            }
            else
            {
                //unsuccessful update
                return -1;
            }

        }
	}
}

