using System;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class RecurtingDbContext: DbContext
	{

        // DbContextOptions is a predefined class in EntityFrameworkCore that is used to pass the connection string to the DbContext class, it is a generic class that takes the DbContext class as a type parameter, here the option parameter is of type DbContextOptions<RecurtingDbContext> which is the DbContext class that we have created.
    
        // the reason we use  : base(option) is because we are inheriting the DbContext class and we need to pass the connection string to the base class.
        public RecurtingDbContext(DbContextOptions<RecurtingDbContext> option) : base(option)
        {
        }

        // This is the DbSet property that is used to create a table in the database, here the property is of type Candidate which is the class that we have created in the ApplicationCore/Entities folder.
        public DbSet<Candidate> Candidates { get; set; }

        
	}
}

