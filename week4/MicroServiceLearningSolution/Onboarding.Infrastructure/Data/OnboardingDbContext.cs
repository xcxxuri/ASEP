using System;
using Microsoft.EntityFrameworkCore;
using Onboarding.ApplicationCore.Entities;

namespace Onboarding.Infrastructure.Data
{
	public class OnboardingDbContext: DbContext
	{
		public OnboardingDbContext(DbContextOptions<OnboardingDbContext> option) : base (option)
		{
		}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCategory> EmployeeCategories { get; set; }
        public DbSet<EmployeeRole> EmployeeRoles { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
	}
}

