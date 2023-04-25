using System;
namespace Interview.ApplicationCore.Models
{
    public class InterviewsResponseModel
    {
        public int Id { get; set; }
        public int RecruiterId { get; set; }
        public int SubmissionId { get; set; }
        public int InterviewTypeId { get; set; }
        public int InterviewRound { get; set; }
        public DateTime SchduledOn { get; set; }
        public int InterviewerId { get; set; }
        public int FeedbackId { get; set; }
    }
}

