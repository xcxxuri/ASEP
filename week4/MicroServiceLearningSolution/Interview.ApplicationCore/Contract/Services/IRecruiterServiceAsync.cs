using System;
using Interview.ApplicationCore.Models;

namespace Interview.ApplicationCore.Contract.Services
{
    public interface IRecruiterServiceAsync
    {
        Task<IEnumerable<RecruiterResponseModel>> GetAllRecruiterAsync();
        Task<RecruiterResponseModel> GetRecruiterByIdAsync(int id);
        Task<int> AddRecruiterAsync(RecruiterRequestModel recruiter);
        Task<int> UpdateRecruiterAsync(RecruiterRequestModel recruiter);
        Task<int> DeleteRecruiterAsync(int id);
    }
}

