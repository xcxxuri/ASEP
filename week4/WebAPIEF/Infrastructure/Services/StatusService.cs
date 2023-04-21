﻿using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Infrastructure.Helper;

namespace Infrastructure.Services
{
	public class StatusService : IStatusService
    {
        IStatusRepository statusRepository;
        ISubmissionRepository submissionRepository;
        public StatusService(IStatusRepository _status, ISubmissionRepository submissionRepository)
        {
            statusRepository = _status;
            this.submissionRepository = submissionRepository;
        }
        public async Task<int> AddStatusAsync(StatusRequestModel model)
        {
            //Looks for the associated submission to compare status states.If it isnt changed, reject status addition.
            var relevantSubmission = await submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.CandidateId == model.CandidateId && 
                s.JobRequirementId == model.JobRequirementId, s => s.Status);
            //Last changed status
            var statusList = relevantSubmission.Status.Count -1;
            var existingStatus = relevantSubmission.Status.FirstOrDefault(s => s.Id == relevantSubmission.Status[statusList].Id);
            if (existingStatus != null && existingStatus.State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if (model != null)
            {
                status.SubmissionId = relevantSubmission.Id;
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                status.Submission = relevantSubmission;
            }
            //returns number of rows affected, typically 1
            return await statusRepository.InsertAsync(status);
        }

        public async Task<int> DeleteStatusAsync(int id)
        {
            //returns number of rows affected, typically 1
            return await statusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StatusResponseModel>> GetAllStatus()
        {
            var statuses = await statusRepository.GetAllAsync();
            var response = statuses.Select(x => x.ToStatusResponseModel());
            return response;
        }

        public async Task<StatusResponseModel> GetStatusByIdAsync(int id)
        {
            var stat = await statusRepository.GetByIdAsync(id);
            if (stat != null)
            {
                var response = stat.ToStatusResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("Status", id);
            }
        }

        public async Task<int> UpdateStatusAsync(StatusRequestModel model)
        {
            // Could be improved because now we have status Id but its fine 
            var relevantSubmission = await submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.Id == model.SubmissionId, s => s.Status);
            //Last changed status
            var statusList = relevantSubmission.Status.Count - 1;
            var existingStatus = relevantSubmission.Status.FirstOrDefault(s => s.Id == relevantSubmission.Status[statusList].Id);
            if (existingStatus != null && existingStatus.State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if (model != null)
            {
                status.Id = model.Id;
                status.SubmissionId = model.SubmissionId;
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                return await statusRepository.UpdateAsync(status);
            }
            
            else
            {
                //unsuccessful update
                return -1;
            }

        }
    }
}

