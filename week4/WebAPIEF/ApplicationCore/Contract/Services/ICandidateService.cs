using System;
using ApplicationCore.Models;

namespace ApplicationCore.Contract.Services
{
	public interface ICandidateService
	{
        //int AddCandidate(CandidateRequestModel model);
        Task<int> AddCandidateAsync(CandidateRequestModel model);
        Task<int> UpdateCandidateAsync(CandidateRequestModel model);
        Task<int> DeleteCandidateAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidates();
        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
    }
}

