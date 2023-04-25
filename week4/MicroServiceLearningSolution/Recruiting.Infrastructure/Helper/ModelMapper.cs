using System;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.Infrastructure.Helper
{
    public static class ModelMapper
    {
        public static CandidateResponseModel ToCandidateResponseModel(this Candidate candidate)
        {
            return new CandidateResponseModel
            {
                Id = candidate.Id,
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                MiddleName = candidate.MiddleName,
                ResumeURL = candidate.ResumeURL
            };
        }

        public static Candidate ToCandidate(this CandidateRequestModel candidateRequestModel, bool hasId)
        {
            var candidate = new Candidate()
            {
                FirstName = candidateRequestModel.FirstName,
                MiddleName = candidateRequestModel.MiddleName,
                LastName = candidateRequestModel.LastName,
                Email = candidateRequestModel.Email,
                ResumeURL = candidateRequestModel.ResumeURL,
            };
            if (hasId)
            {
                candidate.Id = candidateRequestModel.Id;
            }
            return candidate;
        }

        // To JobRequirementResponseModel
        public static JobRequirementResponseModel ToJobRequirementResponseModel(this JobRequirement jobRequirement)
        {
            return new JobRequirementResponseModel
            {
                Id = jobRequirement.Id,
                NumberOfPositions = jobRequirement.NumberOfPositions,
                Title = jobRequirement.Title,
                Description = jobRequirement.Description,
                HiringManagerId = jobRequirement.HiringManagerId,
                HiringManagerName = jobRequirement.HiringManagerName,
                StartDate = jobRequirement.StartDate,
                IsActive = jobRequirement.IsActive,
                ClosedReason = jobRequirement.ClosedReason,
                CreatedOn = jobRequirement.CreatedOn
            };
        }

        // To JobRequirement
        public static JobRequirement ToJobRequirement(this JobRequirementRequestModel jobRequirementRequestModel, bool hasId)
        {
            var jobRequirement = new JobRequirement()
            {
                NumberOfPositions = jobRequirementRequestModel.NumberOfPositions,
                Title = jobRequirementRequestModel.Title,
                Description = jobRequirementRequestModel.Description,
                HiringManagerId = jobRequirementRequestModel.HiringManagerId,
                HiringManagerName = jobRequirementRequestModel.HiringManagerName,
                StartDate = jobRequirementRequestModel.StartDate,
                IsActive = jobRequirementRequestModel.IsActive,
                ClosedReason = jobRequirementRequestModel.ClosedReason,
                CreatedOn = jobRequirementRequestModel.CreatedOn,
                JobCategory = jobRequirementRequestModel.JobCategory,
                EmployeeType = jobRequirementRequestModel.EmployeeType
            };
            if (hasId)
            {
                jobRequirement.Id = jobRequirementRequestModel.Id;
            }
            return jobRequirement;
        }

        // To SubmissionResponseModel
        public static SubmissionResponseModel ToSubmissionResponseModel(this Submission submission)
        {
            return new SubmissionResponseModel
            {
                Id = submission.Id,
                JobRequirementId = submission.JobRequirementId,
                CandidateId = submission.CandidateId,
                SubmittedOn = submission.SubmittedOn,
                SubmissionStatusCode = submission.SubmissionStatusCode,
                CreatedOn = submission.CreatedOn,
                RejectedOn  = submission.RejectedOn
            };
        }

        // To Submission
        public static Submission ToSubmission(this SubmissionRequestModel submissionRequestModel, bool hasId)
        {
            var submission = new Submission()
            {
                JobRequirementId = submissionRequestModel.JobRequirementId,
                CandidateId = submissionRequestModel.CandidateId,
                SubmittedOn = submissionRequestModel.SubmittedOn,
                SubmissionStatusCode = submissionRequestModel.SubmissionStatusCode,
                CreatedOn = submissionRequestModel.CreatedOn,
                RejectedOn = submissionRequestModel.RejectedOn
            };
            if (hasId)
            {
                submission.Id = submissionRequestModel.Id;
            }
            return submission;
        }

        // To SubmissionStatusResponseModel
        public static SubmissionStatusResponseModel ToSubmissionStatusResponseModel(this SubmissionStatus submissionStatus)
        {
            return new SubmissionStatusResponseModel
            {
                Id = submissionStatus.Id,
                Description = submissionStatus.Description
            };
        }

        // To SubmissionStatus
        public static SubmissionStatus ToSubmissionStatus(this SubmissionStatusRequestModel submissionStatusRequestModel, bool hasId)
        {
            var submissionStatus = new SubmissionStatus()
            {
                Description = submissionStatusRequestModel.Description
            };
            if (hasId)
            {
                submissionStatus.Id = submissionStatusRequestModel.Id;
            }
            return submissionStatus;
        }
    }

}
