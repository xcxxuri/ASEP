using System;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Contract.Services
{
    public interface IJobRequirementServiceAsync
    {
        Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirementAsync();
        Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id);
        Task<int> AddJobRequirementAsync(JobRequirementRequestModel candidate);
        Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel candidate);
        Task<int> DeleteJobRequirementAsync(int id);
    }
}

