using System;
using ApplicationCore.Entities;
using HRMMVC.Models;

namespace Infrastructure.Helper
{
    public static class MapHelper
    {
        public static Candidate CandidateRequestToCandidate(CandidateRequestModel model)
        {
            // new a candidate object and set the properties of the object to the properties of the model
            return new Candidate
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Email = model.Email,
                ResumeURL = model.ResumeURL
            };

        }
    }
}

