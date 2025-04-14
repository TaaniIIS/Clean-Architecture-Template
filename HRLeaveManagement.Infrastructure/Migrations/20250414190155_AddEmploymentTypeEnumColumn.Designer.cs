﻿// <auto-generated />
using System;
using HRLeaveManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRLeaveManagement.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250414190155_AddEmploymentTypeEnumColumn")]
    partial class AddEmploymentTypeEnumColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.CompanyLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompanyLocations");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmploymentTypeID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveTypeID")
                        .HasColumnType("int");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("PositionID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("EmploymentTypeID");

                    b.HasIndex("LocationID");

                    b.HasIndex("PositionID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.EmploymentType", b =>
                {
                    b.Property<int>("EmploymentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmploymentTypeID"));

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("EmploymentTypeID");

                    b.ToTable("EmploymentTypes");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.LeaveRequest", b =>
                {
                    b.Property<int>("LeaveRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveRequestID"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("LeaveAmount")
                        .HasColumnType("int");

                    b.Property<int>("LeaveTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaveRequestID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("LeaveTypeID");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.LeaveType", b =>
                {
                    b.Property<int>("LeaveTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LeaveTypeID"));

                    b.Property<int>("DefaultDays")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaveTypeID");

                    b.ToTable("LeaveTypes");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.Position", b =>
                {
                    b.Property<int>("PositionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("JobLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.WorkSchedule", b =>
                {
                    b.Property<int>("WorkScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkScheduleID"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("WorkScheduleID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("WorkSchedules");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.Employee", b =>
                {
                    b.HasOne("HRLeaveManagement.CoreBusiness.Entity.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRLeaveManagement.CoreBusiness.Entity.EmploymentType", "EmploymentType")
                        .WithMany("Employees")
                        .HasForeignKey("EmploymentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRLeaveManagement.CoreBusiness.Entity.CompanyLocation", "Location")
                        .WithMany("Employees")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRLeaveManagement.CoreBusiness.Entity.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("EmploymentType");

                    b.Navigation("Location");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.LeaveRequest", b =>
                {
                    b.HasOne("HRLeaveManagement.CoreBusiness.Entity.Employee", "Employee")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HRLeaveManagement.CoreBusiness.Entity.LeaveType", "LeaveType")
                        .WithMany("LeaveRequests")
                        .HasForeignKey("LeaveTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("LeaveType");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.WorkSchedule", b =>
                {
                    b.HasOne("HRLeaveManagement.CoreBusiness.Entity.Employee", "Employee")
                        .WithMany("WorkSchedules")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.CompanyLocation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.Employee", b =>
                {
                    b.Navigation("LeaveRequests");

                    b.Navigation("WorkSchedules");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.EmploymentType", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.LeaveType", b =>
                {
                    b.Navigation("LeaveRequests");
                });

            modelBuilder.Entity("HRLeaveManagement.CoreBusiness.Entity.Position", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
