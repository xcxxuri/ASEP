using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recruiting.ApplicationCore.Models
{
    public class SubmissionRequestModel
    {
        public int Id { get; set; }
        [Required]
        // Data Annonitation Foreign Key
        [ForeignKey("JobRequirement")]
        public int JobRequirementId { get; set; }
        [Required]
        [ForeignKey("Candidate")]
        public int CandidateId { get; set; }
        public DateTime SubmittedOn { get; set; }
        [Required]
        [ForeignKey("SubmissionStatus")]
        public int SubmissionStatusCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime RejectedOn { get; set; }
    }
}

