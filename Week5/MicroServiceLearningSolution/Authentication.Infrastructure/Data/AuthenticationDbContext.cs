using System;
using Authentication.ApplicationCore.Entities;
using Authentication.ApplicationCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Infrastructure.Data
{
    public class AuthenticationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> option) : base(option)
        {
        }

        // we will not using the se Entities so migration will not create these tables
        // public DbSet<Account> Account { get; set; }
        // public DbSet<UserRole> UserRole { get; set; }
        // public DbSet<Role> Role { get; set; }

    }
}

