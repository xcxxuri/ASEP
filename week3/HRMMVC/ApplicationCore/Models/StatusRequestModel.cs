using System;
namespace ApplicationCore.Models
{
    public class StatusRequestModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobRequirementId { get; set; }
        public string State { get; set; }
        public string StatusMessage { get; set; }
        public int SubmissionId { get; set; }
    }
}

