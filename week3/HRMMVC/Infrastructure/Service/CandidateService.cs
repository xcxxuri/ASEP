using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using HRMMVC.Models;
using Infrastructure.Helper;
using Infrastructure.Repositories;

namespace Infrastructure.Service
{
    public class CandidateService : ICandidateService
    {
        ICandidateRepository _candidateRepository;
        public CandidateService(CandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        // public int AddCandidate(CandidateRequestModel model)
        // {
        //     // 可以直接调用CandidateRequestToCandidate方法，因为这个方法是static的
        //     var candidate = MapHelper.CandidateRequestToCandidate(model);
        //     _candidateRepository.Insert(candidate);
        //     return 1;
        // }

        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            var existingCandidate = await _candidateRepository.GetCandidateByEmail(model.Email);
            if (existingCandidate != null)
            {
                throw new Exception("Email is already used");
            }
            Candidate candidate = new Candidate();
            if (model != null)
            {
                candidate.FirstName = model.FirstName;
                candidate.MiddleName = model.MiddleName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
            }
            //returns number of rows affected, typically 1
            return await _candidateRepository.InsertAsync(candidate);
        }

        public async Task<int> DeleteCandidateAsync(int id)
        {
            return await _candidateRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidates()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            var response = candidates.Select(x => x.ToCandidateResponseModel());
            return response;
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null)
            {
                throw new NotFoundException("Candidate not found", id);
            }
            else
            {
                var response = candidate.ToCandidateResponseModel();
                return response;
            }

        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            var existingCandidate = await _candidateRepository.GetByIdAsync(model.Id);
            if (existingCandidate == null)
            {
                throw new NotFoundException("Candidate not found", model.Id);
            }
            Candidate candidate = new Candidate();
            if (model != null)
            {
                candidate.Id = model.Id;
                candidate.FirstName = model.FirstName;
                candidate.MiddleName = model.MiddleName;
                candidate.LastName = model.LastName;
                candidate.Email = model.Email;
                candidate.ResumeURL = model.ResumeURL;
                return await _candidateRepository.UpdateAsync(candidate);
            }
            else
            {
                // unsuccessful update
                return -1;
            }

        }

    }
}

