using System;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class RecurtingDbContext : DbContext
	{
		public RecurtingDbContext(DbContextOptions<RecurtingDbContext> option) : base(option)
        {
        }

        // This is the DbSet property that is used to create a table in the database, here the property is of type Candidate which is the class that we have created in the ApplicationCore/Entities folder.
        public DbSet<Candidate> Candidates { get; set; }
	}
}

