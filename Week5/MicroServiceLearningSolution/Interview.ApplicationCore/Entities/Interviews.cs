using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interview.ApplicationCore.Entities
{
    public class Interviews
    {
        [Required]
        public int Id { get; set; }
        [ForeignKey("Recruiter")]
        public int RecruiterId { get; set; }
        public int SubmissionId { get; set; }
        [ForeignKey("InterviewType")]
        public int InterviewTypeId { get; set; }
        public int InterviewRound { get; set; }
        public DateTime SchduledOn { get; set; }
        [ForeignKey("Interviewer")]
        public int InterviewerId { get; set; }
        [ForeignKey("InterviewFeedback")]
        public int FeedbackId { get; set; }
    }
}

