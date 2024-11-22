﻿// <auto-generated />
using System;
using HRApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241118143834_AddMoreEmployeees")]
    partial class AddMoreEmployeees
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("HRApp.Models.CalendarEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("End")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsApproved")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsCompanyWide")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Start")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("HRApp.Models.Employees", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("LeaveDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salary")
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = "Engineering",
                            Email = "ebissill0@mac.com",
                            FirstName = "Evaleen",
                            Gender = "Female",
                            JoinDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Bissill",
                            Salary = "£28110.63"
                        },
                        new
                        {
                            Id = 2,
                            Department = "Accounting",
                            Email = "cmulvey1@abc.net.au",
                            FirstName = "Chrisy",
                            Gender = "Male",
                            JoinDate = new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Mulvey",
                            LeaveDate = new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = "£34886.72"
                        },
                        new
                        {
                            Id = 3,
                            Department = "Marketing",
                            Email = "sthompson2@abc.net.au",
                            FirstName = "Sarah",
                            Gender = "Female",
                            JoinDate = new DateTime(2022, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Thompson",
                            Salary = "£42150.89"
                        },
                        new
                        {
                            Id = 4,
                            Department = "IT",
                            Email = "jchen3@abc.net.au",
                            FirstName = "James",
                            Gender = "Male",
                            JoinDate = new DateTime(2023, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Chen",
                            LeaveDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = "£51275.33"
                        },
                        new
                        {
                            Id = 5,
                            Department = "HR",
                            Email = "ewright4@abc.net.au",
                            FirstName = "Emma",
                            Gender = "Female",
                            JoinDate = new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Wright",
                            Salary = "£38992.45"
                        },
                        new
                        {
                            Id = 6,
                            Department = "Sales",
                            Email = "mobrien5@abc.net.au",
                            FirstName = "Michael",
                            Gender = "Male",
                            JoinDate = new DateTime(2022, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "O'Brien",
                            LeaveDate = new DateTime(2024, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = "£45678.90"
                        },
                        new
                        {
                            Id = 7,
                            Department = "Product Management",
                            Email = "rquadrio2@wufoo.com",
                            FirstName = "Ronni",
                            Gender = "Male",
                            JoinDate = new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Quadrio",
                            Salary = "£56447.51"
                        },
                        new
                        {
                            Id = 8,
                            Department = "Services",
                            Email = "cbroseman3@cam.ac.uk",
                            FirstName = "Chery",
                            Gender = "Female",
                            JoinDate = new DateTime(2023, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Broseman",
                            LeaveDate = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = "£42535.58"
                        },
                        new
                        {
                            Id = 9,
                            Department = "Human Resources",
                            Email = "lbeadnall4@livejournal.com",
                            FirstName = "Lelia",
                            Gender = "Female",
                            JoinDate = new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Beadnall",
                            Salary = "£57500.48"
                        },
                        new
                        {
                            Id = 10,
                            Department = "Legal",
                            Email = "aeslinger5@cam.ac.uk",
                            FirstName = "Archibold",
                            Gender = "Male",
                            JoinDate = new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Eslinger",
                            Salary = "£32775.63"
                        },
                        new
                        {
                            Id = 11,
                            Department = "Research and Development",
                            Email = "vmacarthur6@desdev.cn",
                            FirstName = "Vida",
                            Gender = "Female",
                            JoinDate = new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "MacArthur",
                            LeaveDate = new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Salary = "£58116.07"
                        },
                        new
                        {
                            Id = 12,
                            Department = "Training",
                            Email = "orapin7@guardian.co.uk",
                            FirstName = "Odey",
                            Gender = "Male",
                            JoinDate = new DateTime(2023, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Rapin",
                            Salary = "£32643.37"
                        },
                        new
                        {
                            Id = 13,
                            Department = "Support",
                            Email = "jcottem8@fotki.com",
                            FirstName = "Jacquenetta",
                            Gender = "Female",
                            JoinDate = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Cottem",
                            Salary = "£20902.55"
                        },
                        new
                        {
                            Id = 14,
                            Department = "Accounting",
                            Email = "amullaly9@toplist.cz",
                            FirstName = "Arny",
                            Gender = "Male",
                            JoinDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Mullaly",
                            Salary = "£53201.85"
                        });
                });

            modelBuilder.Entity("HRApp.Models.TimeOffRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("TimeOffRequests");
                });

            modelBuilder.Entity("HRApp.Models.CalendarEvent", b =>
                {
                    b.HasOne("HRApp.Models.Employees", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HRApp.Models.TimeOffRequest", b =>
                {
                    b.HasOne("HRApp.Models.Employees", "Employee")
                        .WithMany("TimeOffRequests")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HRApp.Models.Employees", b =>
                {
                    b.Navigation("TimeOffRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
