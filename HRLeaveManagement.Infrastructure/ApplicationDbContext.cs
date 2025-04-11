using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Web.Domain.Entity;

namespace HRLeaveManagement.Infrastructure
{
    // This class represents the database context of your application.
    // It inherits from 'IdentityDbContext<IdentityUser>', so it includes tables for user authentication and authorization.
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        // Constructor that takes in configuration options (like connection string, provider, etc.)
        // and passes them to the base class (IdentityDbContext).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // This property represents the 'Positions' table in your database.
        // EF Core will use this to track, query, and save Position entities.
        public virtual DbSet<Position> positions { get; set; }
    }

}
