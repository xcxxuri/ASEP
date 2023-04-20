﻿using System;
namespace ApplicationCore.Models
{
	public class SubmissionRequestModel
	{
        public int Id { get; set; }
        public int JobRequirementId { get; set; }
        public int CandidateId { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime SubmittedOn { get; set; }
        public DateTime ConfirmedOn { get; set; }
        public DateTime RejectedOn { get; set; }
    }
}

