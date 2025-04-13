using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.CoreBusiness.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HRLeaveManagement.Infrastructure
{
    // This class represents the database context of your application.
    // It inherits from 'IdentityDbContext<IdentityUser>', so it includes tables for user authentication and authorization.
    public class ApplicationDbContext : DbContext/// IdentityDbContext<IdentityUser>
    {
        // Constructor that takes in configuration options (like connection string, provider, etc.)
        // and passes them to the base class (IdentityDbContext).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // This property represents the 'Positions' table in your database.
        // EF Core will use this to track, query, and save Position entities.
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<Team> Teams { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<EmploymentType> EmploymentTypes { get; set; }
        public DbSet<CompanyLocation> CompanyLocations { get; set; }
        public DbSet<WorkSchedule> WorkSchedules { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }

















       // Infrastructure/Data/ApplicationDbContext.cs
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Employee relationships
        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.Position)
        //        .WithMany(p => p.Employees)
        //        .HasForeignKey(e => e.PositionID);

        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.Department)
        //        .WithMany(d => d.Employees)
        //        .HasForeignKey(e => e.DepartmentID);

        //    //modelBuilder.Entity<Employee>()
        //    //    .HasOne(e => e.Team)
        //    //    .WithMany(t => t.Members)
        //    //    .HasForeignKey(e => e.TeamID);

        //    //modelBuilder.Entity<Employee>()
        //    //    .HasOne(e => e.Manager)
        //    //    .WithMany(e => e.Subordinates)
        //    //    .HasForeignKey(e => e.ManagerID)
        //    //    .OnDelete(DeleteBehavior.Restrict);

        //    // Team relationships
        //    //modelBuilder.Entity<Team>()
        //    //    .HasOne(t => t.Department)
        //    //    .WithMany(d => d.Teams)
        //    //    .HasForeignKey(t => t.DepartmentID);

        //    //modelBuilder.Entity<Team>()
        //    //    .HasOne(t => t.Manager)
        //    //    .WithMany()
        //    //    .HasForeignKey(t => t.ManagerID);

        //    // LeaveRequest relationships
        //    modelBuilder.Entity<LeaveRequest>()
        //        .HasOne(lr => lr.Employee)
        //        .WithMany(e => e.LeaveRequests)
        //        .HasForeignKey(lr => lr.EmployeeID);
        //}























        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    1.Department(Your Sample)
        //    modelBuilder.Entity<Department>(entity =>
        //    {
        //        entity.HasKey(d => d.DepartmentID);
        //        entity.Property(d => d.Name).IsRequired().HasMaxLength(100);

        //        entity.HasMany(d => d.Teams)
        //              .WithOne(t => t.Department)
        //              .HasForeignKey(t => t.DepartmentID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasMany(d => d.Employees)
        //              .WithOne(e => e.Department)
        //              .HasForeignKey(e => e.DepartmentID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    2.Team
        //    modelBuilder.Entity<Team>(entity =>
        //    {
        //        entity.HasKey(t => t.TeamID);
        //        entity.Property(t => t.Name).IsRequired().HasMaxLength(100);

        //        Department relationship already configured above

        //        entity.HasMany(t => t.Members)
        //              .WithOne(e => e.Team)
        //              .HasForeignKey(e => e.TeamID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(t => t.Manager)
        //              .WithMany(e => e.ManagedTeams)
        //              .HasForeignKey(t => t.ManagerID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    3.Position
        //    modelBuilder.Entity<Position>(entity =>
        //    {
        //        entity.HasKey(p => p.PositionID);
        //        entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
        //        entity.Property(p => p.JobLevel).HasMaxLength(50);

        //        entity.HasMany(p => p.Employees)
        //              .WithOne(e => e.Position)
        //              .HasForeignKey(e => e.PositionID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    4.EmploymentType
        //    modelBuilder.Entity<EmploymentType>(entity =>
        //    {
        //        entity.HasKey(et => et.EmploymentTypeID);
        //        entity.Property(et => et.Name).IsRequired().HasMaxLength(50);

        //        entity.HasMany(et => et.Employees)
        //              .WithOne(e => e.EmploymentType)
        //              .HasForeignKey(e => e.EmploymentTypeID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    5.CompanyLocation
        //    modelBuilder.Entity<CompanyLocation>(entity =>
        //    {
        //        entity.HasKey(cl => cl.Id);
        //        entity.Property(cl => cl.Address).IsRequired().HasMaxLength(200);

        //        entity.HasMany(cl => cl.Employees)
        //              .WithOne(e => e.Location)
        //              .HasForeignKey(e => e.LocationID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    6.Employee(Most Complex)
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasKey(e => e.EmployeeID);
        //        entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
        //        entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
        //        entity.Property(e => e.Email).IsRequired().HasMaxLength(100);

        //        All relationships are configured from the other side
        //         except for self - referencing:

        //        entity.HasMany(e => e.Subordinates)
        //              .WithOne(e => e.Manager)
        //              .HasForeignKey(e => e.ManagerID)
        //              .IsRequired(false)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasMany(e => e.ManagedTeams)
        //              .WithOne(t => t.Manager)
        //              .HasForeignKey(t => t.ManagerID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasMany(e => e.LeaveRequests)
        //              .WithOne(lr => lr.Employee)
        //              .HasForeignKey(lr => lr.EmployeeID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasMany(e => e.WorkSchedules)
        //              .WithOne(ws => ws.Employee)
        //              .HasForeignKey(ws => ws.EmployeeID)
        //              .OnDelete(DeleteBehavior.Cascade);
        //    });

        //    7.WorkSchedule
        //    modelBuilder.Entity<WorkSchedule>(entity =>
        //    {
        //        entity.HasKey(ws => ws.WorkScheduleID);

        //        Employee relationship configured above
        //    });

        //    8.LeaveType
        //    modelBuilder.Entity<LeaveType>(entity =>
        //    {
        //        entity.HasKey(lt => lt.LeaveTypeID);
        //        entity.Property(lt => lt.Name).IsRequired().HasMaxLength(50);

        //        entity.HasMany(lt => lt.LeaveRequests)
        //              .WithOne(lr => lr.LeaveType)
        //              .HasForeignKey(lr => lr.LeaveTypeID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    9.LeaveRequest
        //    modelBuilder.Entity<LeaveRequest>(entity =>
        //    {
        //        entity.HasKey(lr => lr.LeaveRequestID);
        //        entity.Property(lr => lr.Status).IsRequired().HasMaxLength(20);

        //        Employee and LeaveType relationships configured above
        //    });

        //    Indexes
        //    modelBuilder.Entity<Employee>()
        //        .HasIndex(e => new { e.DepartmentID, e.TeamID, e.ManagerID });

        //    modelBuilder.Entity<LeaveRequest>()
        //        .HasIndex(lr => new { lr.EmployeeID, lr.LeaveTypeID });
        //}











        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    // 1. Department Configuration
        //    modelBuilder.Entity<Department>(entity =>
        //    {
        //        entity.HasKey(d => d.DepartmentID);
        //        entity.Property(d => d.Name).IsRequired().HasMaxLength(100);

        //        // Relationships
        //        entity.HasMany(d => d.Teams)
        //              .WithOne(t => t.Department)
        //              .HasForeignKey(t => t.DepartmentID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    // 2. Team Configuration
        //    modelBuilder.Entity<Team>(entity =>
        //    {
        //        entity.HasKey(t => t.TeamID);
        //        entity.Property(t => t.Name).IsRequired().HasMaxLength(100);

        //        // Relationships
        //        entity.HasOne(t => t.Manager)
        //              .WithMany()
        //              .HasForeignKey(t => t.ManagerID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    // 3. Position Configuration
        //    modelBuilder.Entity<Position>(entity =>
        //    {
        //        entity.HasKey(p => p.PositionID);
        //        entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
        //        entity.Property(p => p.JobLevel).HasMaxLength(50);
        //    });

        //    // 4. EmploymentType Configuration
        //    modelBuilder.Entity<EmploymentType>(entity =>
        //    {
        //        entity.HasKey(et => et.EmploymentTypeID);
        //        entity.Property(et => et.Name).IsRequired().HasMaxLength(50);
        //    });

        //    // 5. CompanyLocation Configuration
        //    modelBuilder.Entity<CompanyLocation>(entity =>
        //    {
        //        entity.HasKey(cl => cl.Id);
        //        entity.Property(cl => cl.Address).IsRequired().HasMaxLength(200);
        //    });

        //    // 6. Employee Configuration (Most Complex)
        //    modelBuilder.Entity<Employee>(entity =>
        //    {
        //        entity.HasKey(e => e.EmployeeID);

        //        // Property Configurations
        //        entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
        //        entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
        //        entity.Property(e => e.Email).IsRequired().HasMaxLength(100);

        //        // Relationships
        //        entity.HasOne(e => e.Department)
        //              .WithMany(d => d.Employees)
        //              .HasForeignKey(e => e.DepartmentID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(e => e.Position)
        //              .WithMany(p => p.Employees)
        //              .HasForeignKey(e => e.PositionID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(e => e.Team)
        //              .WithMany(t => t.Members)
        //              .HasForeignKey(e => e.TeamID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(e => e.EmploymentType)
        //              .WithMany(et => et.Employees)
        //              .HasForeignKey(e => e.EmploymentTypeID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(e => e.Location)
        //              .WithMany(l => l.Employees)
        //              .HasForeignKey(e => e.LocationID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        // Self-referencing relationship
        //        entity.HasOne(e => e.Manager)
        //              .WithMany(e => e.Subordinates)
        //              .HasForeignKey(e => e.ManagerID)
        //              .IsRequired(false)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    // 7. WorkSchedule Configuration
        //    modelBuilder.Entity<WorkSchedule>(entity =>
        //    {
        //        entity.HasKey(ws => ws.WorkScheduleID);

        //        entity.HasOne(ws => ws.Employee)
        //              .WithMany(e => e.WorkSchedules)
        //              .HasForeignKey(ws => ws.EmployeeID)
        //              .OnDelete(DeleteBehavior.Cascade);
        //    });

        //    // 8. LeaveType Configuration
        //    modelBuilder.Entity<LeaveType>(entity =>
        //    {
        //        entity.HasKey(lt => lt.LeaveTypeID);
        //        entity.Property(lt => lt.Name).IsRequired().HasMaxLength(50);
        //    });

        //    // 9. LeaveRequest Configuration
        //    modelBuilder.Entity<LeaveRequest>(entity =>
        //    {
        //        entity.HasKey(lr => lr.LeaveRequestID);
        //        entity.Property(lr => lr.Status).IsRequired().HasMaxLength(20);

        //        // Relationships
        //        entity.HasOne(lr => lr.Employee)
        //              .WithMany(e => e.LeaveRequests)
        //              .HasForeignKey(lr => lr.EmployeeID)
        //              .OnDelete(DeleteBehavior.Restrict);

        //        entity.HasOne(lr => lr.LeaveType)
        //              .WithMany(lt => lt.LeaveRequests)
        //              .HasForeignKey(lr => lr.LeaveTypeID)
        //              .OnDelete(DeleteBehavior.Restrict);
        //    });

        //    // Indexes for Performance
        //    modelBuilder.Entity<Employee>()
        //        .HasIndex(e => e.DepartmentID);

        //    modelBuilder.Entity<Employee>()
        //        .HasIndex(e => e.TeamID);

        //    modelBuilder.Entity<Employee>()
        //        .HasIndex(e => e.ManagerID);

        //    modelBuilder.Entity<LeaveRequest>()
        //        .HasIndex(lr => lr.EmployeeID);

        //    modelBuilder.Entity<LeaveRequest>()
        //        .HasIndex(lr => lr.LeaveTypeID);
        //}










    }

}
