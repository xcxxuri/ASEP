using System;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Contract.Services
{
	public interface ISubmissionStatusServiceAsync
	{
        Task<IEnumerable<SubmissionStatusResponseModel>> GetAllSubmissionStatusAsync();
        Task<SubmissionStatusResponseModel> GetSubmissionStatusByIdAsync(int id);
        Task<int> AddSubmissionStatusAsync(SubmissionStatusRequestModel candidate);
        Task<int> UpdateSubmissionStatusAsync(SubmissionStatusRequestModel candidate);
        Task<int> DeleteSubmissionStatusAsync(int id);
	}
}

