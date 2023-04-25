using System;
using Microsoft.EntityFrameworkCore;
using Recruiting.ApplicationCore.Entities;

namespace Recruiting.Infrastructure.Data
{
	public class RecruitingDbContext : DbContext
	{
		public RecruitingDbContext(DbContextOptions<RecruitingDbContext> option) : base (option)
		{
		}

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobRequirement> JobRequirements { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<SubmissionStatus> SubmissionRequirements { get; set; }
	}
}

