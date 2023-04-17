using System;
using HRMMVC.Models;

namespace ApplicationCore.Contract.Services
{
    public interface ICandidateService
    {
        int AddCandidate(CandidateRequestModel model);
    }
}

