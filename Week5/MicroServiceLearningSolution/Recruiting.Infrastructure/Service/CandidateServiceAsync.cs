using System;
using Recruiting.ApplicationCore.Contract.Repositories;
using Recruiting.ApplicationCore.Contract.Services;
using Recruiting.ApplicationCore.Entities;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helper;

namespace Recruiting.Infrastructure.Service
{
    public class CandidateServiceAsync : ICandidateServiceAsync
    {

        private readonly ICandidateRepositoryAsync _candidateRepositoryAsync;
        public CandidateServiceAsync(ICandidateRepositoryAsync candidateRepositoryAsync)
        {
            _candidateRepositoryAsync = candidateRepositoryAsync;
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidateAsync()
        {
            var candidates = await _candidateRepositoryAsync.GetAllAsync();
            var response = candidates.Select(x => x.ToCandidateResponseModel());
            return response;

        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateRepositoryAsync.GetByIdAsync(id);
            var response = candidate.ToCandidateResponseModel();
            return response;
        }

        public async Task<int> AddCandidateAsync(CandidateRequestModel candidatemodel)
        {
            var existingCandidate = await _candidateRepositoryAsync.GetUserByEmail(candidatemodel.Email);
            if (existingCandidate != null)
            {
                //this email has been registered
                throw new Exception("Email is already used");
            }
            Candidate candidate = new Candidate();
            if (candidatemodel != null)
            {
                candidate = candidatemodel.ToCandidate(false);
            }
            return await _candidateRepositoryAsync.InsertAsync(candidate);

        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel candidatemodel)
        {
            var existingCandidate = await _candidateRepositoryAsync.GetByIdAsync(candidatemodel.Id);
            if (existingCandidate == null)
            {
                throw new Exception("Candidate does not exist");
            }
            if (candidatemodel != null)
            {
                Candidate candidate = candidatemodel.ToCandidate(true);
                return await _candidateRepositoryAsync.UpdateAsync(candidate);
            }
            else
            {
                //unsuccessful update
                return -1;
            }
        }

        public async Task<int> DeleteCandidateAsync(int id)
        {
            return await _candidateRepositoryAsync.DeleteAsync(id);
        }


    }
}

