using System;
using ApplicationCore.Contract.Repositories;
using ApplicationCore.Contract.Services;
using HRMMVC.Models;
using Infrastructure.Helper;
using Infrastructure.Repositories;

namespace Infrastructure.Service
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _candidateRepository;
        public CandidateService(CandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public int AddCandidate(CandidateRequestModel model)
        {
            // 可以直接调用CandidateRequestToCandidate方法，因为这个方法是static的
            var candidate = MapHelper.CandidateRequestToCandidate(model);
            _candidateRepository.Insert(candidate);
            return 1;
        }
    }
}

