using System;
using Interview.ApplicationCore.Entities;
using Interview.ApplicationCore.Models;
namespace Interview.Infrastructure.Helper
{
    public static class ModelMapper
    {
        /*
        public static EmployeeStatusResponseModel ToEmployeeStatusResponseModel(this EmployeeStatus employeeStatus)
        {
            return new EmployeeStatusResponseModel
            {
                Id = employeeStatus.Id,
                Description = employeeStatus.Description,
                ABBR = employeeStatus.ABBR
            };
        }

        public static EmployeeStatus ToEmployeeStatus(this EmployeeStatusRequestModel employeeStatusRequestModel, bool hasId)
        {
            var employeeStatus = new EmployeeStatus()
            {
                Description = employeeStatusRequestModel.Description,
                ABBR = employeeStatusRequestModel.ABBR
            };
            if (hasId)
            {
                employeeStatus.Id = employeeStatusRequestModel.Id;
            }
            return employeeStatus;
        }
        */


        // public class Interviewer
        // {
        //     [Required]
        //     [Key]
        //     public int Id { get; set; }
        //     [Required]
        //     [Column(TypeName = "nvarchar(128)")]
        //     public string FirstName { get; set; }
        //     [Required]
        //     [Column(TypeName = "nvarchar(128)")]
        //     public string LastName { get; set; }
        //     public int EmployeeId { get; set; }
        // }

        public static InterviewerResponseModel ToInterviewerResponseModel(this Interviewer interviewer)
        {
            return new InterviewerResponseModel
            {
                Id = interviewer.Id,
                FirstName = interviewer.FirstName,
                LastName = interviewer.LastName,
                EmployeeId = interviewer.EmployeeId
            };
        }

        public static Interviewer ToInterviewer(this InterviewerRequestModel interviewerRequestModel, bool hasId)
        {
            var interviewer = new Interviewer()
            {
                FirstName = interviewerRequestModel.FirstName,
                LastName = interviewerRequestModel.LastName,
                EmployeeId = interviewerRequestModel.EmployeeId
            };
            if (hasId)
            {
                interviewer.Id = interviewerRequestModel.Id;
            }
            return interviewer;
        }

        // public class InterviewFeedback
        // {
        //     [Required]
        //     [Key]
        //     public int Id { get; set; }
        //     [Required]
        //     public int Rating { get; set; }
        //     [Column(TypeName = "varchar(max)")]
        //     public string Comment { get; set; }
        // }

        public static InterviewFeedbackResponseModel ToInterviewFeedbackResponseModel(this InterviewFeedback interviewFeedback)
        {
            return new InterviewFeedbackResponseModel
            {
                Id = interviewFeedback.Id,
                Rating = interviewFeedback.Rating,
                Comment = interviewFeedback.Comment
            };
        }

        public static InterviewFeedback ToInterviewFeedback(this InterviewFeedbackRequestModel interviewFeedbackRequestModel, bool hasId)
        {
            var interviewFeedback = new InterviewFeedback()
            {
                Rating = interviewFeedbackRequestModel.Rating,
                Comment = interviewFeedbackRequestModel.Comment
            };
            if (hasId)
            {
                interviewFeedback.Id = interviewFeedbackRequestModel.Id;
            }
            return interviewFeedback;
        }

        // public class Interviews
        // {
        //     [Required]
        //     [Key]
        //     public int Id { get; set; }
        //     [ForeignKey("Recruiter")]
        //     public int RecruiterId { get; set; }
        //     public int SubmissionId { get; set; }
        //     [ForeignKey("InterviewType")]
        //     public int InterviewTypeId { get; set; }
        //     public int InterviewRound { get; set; }
        //     public DateTime SchduledOn { get; set; }
        //     [ForeignKey("Interviewer")]
        //     public int InterviewerId { get; set; }
        //     [ForeignKey("InterviewFeedback")]
        //     public int FeedbackId { get; set; }
        // }

        public static InterviewsResponseModel ToInterviewsResponseModel(this Interviews interviews)
        {
            return new InterviewsResponseModel
            {
                Id = interviews.Id,
                RecruiterId = interviews.RecruiterId,
                SubmissionId = interviews.SubmissionId,
                InterviewTypeId = interviews.InterviewTypeId,
                InterviewRound = interviews.InterviewRound,
                SchduledOn = interviews.SchduledOn,
                InterviewerId = interviews.InterviewerId,
                FeedbackId = interviews.FeedbackId
            };
        }

        public static Interviews ToInterviews(this InterviewsRequestModel interviewsRequestModel, bool hasId)
        {
            var interviews = new Interviews()
            {
                RecruiterId = interviewsRequestModel.RecruiterId,
                SubmissionId = interviewsRequestModel.SubmissionId,
                InterviewTypeId = interviewsRequestModel.InterviewTypeId,
                InterviewRound = interviewsRequestModel.InterviewRound,
                SchduledOn = interviewsRequestModel.SchduledOn,
                InterviewerId = interviewsRequestModel.InterviewerId,
                FeedbackId = interviewsRequestModel.FeedbackId
            };
            if (hasId)
            {
                interviews.Id = interviewsRequestModel.Id;
            }
            return interviews;
        }

        // public class InterviewType
        // {
        //     [Required]
        //     [Key]
        //     public int Id { get; set; }
        //     [Column(TypeName = "nvarchar(128)")]
        //     public string Description { get; set; }
        // }

        public static InterviewTypeResponseModel ToInterviewTypeResponseModel(this InterviewType interviewType)
        {
            return new InterviewTypeResponseModel
            {
                Id = interviewType.Id,
                Description = interviewType.Description
            };
        }

        public static InterviewType ToInterviewType(this InterviewTypeRequestModel interviewTypeRequestModel, bool hasId)
        {
            var interviewType = new InterviewType()
            {
                Description = interviewTypeRequestModel.Description
            };
            if (hasId)
            {
                interviewType.Id = interviewTypeRequestModel.Id;
            }
            return interviewType;
        }

        // public class Recruiter
        // {
        //     [Required]
        //     [Key]
        //     public int Id { get; set; }
        //     [Required]
        //     [Column(TypeName = "nvarchar(128)")]
        //     public string FirstName { get; set; }
        //     [Required]
        //     [Column(TypeName = "nvarchar(128)")]
        //     public string LastName { get; set; }
        //     public int EmployeeId { get; set; }
        // }

        public static RecruiterResponseModel ToRecruiterResponseModel(this Recruiter recruiter)
        {
            return new RecruiterResponseModel
            {
                Id = recruiter.Id,
                FirstName = recruiter.FirstName,
                LastName = recruiter.LastName,
                EmployeeId = recruiter.EmployeeId
            };
        }

        public static Recruiter ToRecruiter(this RecruiterRequestModel recruiterRequestModel, bool hasId)
        {
            var recruiter = new Recruiter()
            {
                FirstName = recruiterRequestModel.FirstName,
                LastName = recruiterRequestModel.LastName,
                EmployeeId = recruiterRequestModel.EmployeeId
            };
            if (hasId)
            {
                recruiter.Id = recruiterRequestModel.Id;
            }
            return recruiter;
        }

    }
}

