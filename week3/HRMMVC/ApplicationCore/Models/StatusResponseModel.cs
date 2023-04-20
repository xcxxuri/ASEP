using System;
namespace ApplicationCore.Models
{
    public class StatusResponseModel
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public string State { get; set; }
        public DateTime? ChangedOn { get; set; }
        public string StatusMessage { get; set; }
    }
}

