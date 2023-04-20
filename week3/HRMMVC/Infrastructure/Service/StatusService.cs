using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Infrastructure.Helper;

namespace Infrastructure.Service
{
    public class StatusService : IStatusService
    {
        IStatusRepository _statusRepository;
        ISubmissionRepository _submissionRepository;
        public StatusService(IStatusRepository statusRepository, ISubmissionRepository submissionRepository)
        {
            _statusRepository = statusRepository;
            _submissionRepository = submissionRepository;
        }


        public async Task<int> AddStatusAsync(StatusRequestModel model)
        {
            //Looks for the associated submission to compare status states.If it isnt changed, reject status addition.
            var relevantSubmission = await _submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.CandidateId == model.CandidateId &&
                s.JobRequirementId == model.JobRequirementId, s => s.Status);
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
                status.SubmissionId = relevantSubmission.Id;
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                status.Submission = relevantSubmission;
            }
            //returns number of rows affected, typically 1
            return await _statusRepository.InsertAsync(status);
        }

        public async Task<int> DeleteStatusAsync(int id)
        {
            return await _statusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StatusResponseModel>> GetAllStatus()
        {
            var status = await _statusRepository.GetAllAsync();
            var response = status.Select(x => x.ToStatusResponseModel());
            return response;
        }

        public async Task<StatusResponseModel> GetStatusByIdAsync(int id)
        {
            var status = await _statusRepository.GetByIdAsync(id);
            if (status != null)
            {
                return status.ToStatusResponseModel();
            }
            else
            {
                throw new NotFoundException("Status not found", id);
            }

        }

        public async Task<int> UpdateStatusAsync(StatusRequestModel model)
        {
            // Could be improved because now we have status Id but its fine 
            var relevantSubmission = await _submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.Id == model.SubmissionId, s => s.Status);
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
                return await _statusRepository.UpdateAsync(status);
            }

            else
            {
                //unsuccessful update
                return -1;
            }
        }
    }
}

