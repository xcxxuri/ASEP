using System;
namespace Recruiting.ApplicationCore.Models
{
    public class SubmissionResponseModel
    {
        public int Id { get; set; }
        public int JobRequirementId { get; set; }
        public int CandidateId { get; set; }
        public DateTime SubmittedOn { get; set; }
        public int SubmissionStatusCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime RejectedOn { get; set; }
    }
}

