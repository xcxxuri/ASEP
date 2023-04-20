using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Entities;

namespace Infrastructure.Services
{
	public class CandidateService
	{
        private readonly ICandidateRepository _candidateRepository;
        // CandidateRepository _candidateRepository;
        public CandidateService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        // DeleteCandidate
        public int DeleteCandidate(int id)
        {
            return _candidateRepository.DeleteById(id);
        }

        // GetCandidateById
        public Candidate GetCandidateById(int id)
        {
            return _candidateRepository.GetById(id);
        }

        // GetAllCandidates
        public IEnumerable<Candidate> GetAllCandidates()
        {
            return _candidateRepository.GetAll();
        }

        // AddCandidate
        public int AddCandidate(Candidate candidate)
        {
            return _candidateRepository.Insert(candidate);
        }

        // UpdateCandidate
        public int UpdateCandidate(Candidate candidate)
        {
            return _candidateRepository.Update(candidate);
        }
    }
}

