using System;
using Dapper;
using Interview.ApplicationCore.Contract.Repositories;
using Interview.ApplicationCore.Entities;
using Interview.Infrastructure.Data;

namespace Interview.Infrastructure.Repository
{
    public class InterviewsRepositoryAsync : BaseRepositoryAsync<Interviews>, IInterviewsRepositoryAsync
    {
        public InterviewsRepositoryAsync(InterviewDbContext dbContext) : base(dbContext)
        {
        }
        // public class Interviews
        // {
        //     [Required]
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

        public async Task<int> InsertAsync(Interviews entity)
        {
            var query = $"INSERT INTO Interviews VALUES (@RecruiterId, @SubmissionId, @InterviewTypeId, @InterviewRound, @SchduledOn, @InterviewerId, @FeedbackId)";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }

        public async Task<int> UpdateAsync(Interviews entity)
        {
            var query = $"UPDATE Interviews SET RecruiterId = @RecruiterId, SubmissionId = @SubmissionId, InterviewTypeId = @InterviewTypeId, InterviewRound = @InterviewRound, SchduledOn = @SchduledOn, InterviewerId = @InterviewerId, FeedbackId = @FeedbackId WHERE Id = @Id";
            using (var connection = DbContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, entity);
            }
        }
    }
}

