using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Infrastructure.Helper;

namespace Infrastructure.Services
{
	public class CandidateService : ICandidateService
	{
        private readonly ICandidateRepository _candidateRepository;
        // CandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            // Get User By Email uses FirstorDefault which allows Null as return. 
            var existingCandidate = await _candidateRepository.GetUserByEmail(model.Email);
            if(existingCandidate != null)
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
            //returns number of rows affected, typically 1
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
            if (candidate != null)
            {
                var response = candidate.ToCandidateResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("Candidate", id);
            }
        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            var existingCandidate = await _candidateRepository.GetByIdAsync(model.Id);
            if (existingCandidate == null)
            {
                throw new Exception("Candidate does not exist");
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
                //unsuccessful update
                return -1;
            }
            
        }

        // // DeleteCandidate
        // public int DeleteCandidate(int id)
        // {
        //     return _candidateRepository.DeleteById(id);
        // }

        // // GetCandidateById
        // public Candidate GetCandidateById(int id)
        // {
        //     return _candidateRepository.GetById(id);
        // }

        // // GetAllCandidates
        // public IEnumerable<Candidate> GetAllCandidates()
        // {
        //     return _candidateRepository.GetAll();
        // }

        // // AddCandidate
        // public int AddCandidate(Candidate candidate)
        // {
        //     return _candidateRepository.Insert(candidate);
        // }

        // // UpdateCandidate
        // public int UpdateCandidate(Candidate candidate)
        // {
        //     return _candidateRepository.Update(candidate);
        // }
    }
}

