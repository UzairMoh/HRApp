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
    [Migration("20241031113741_ChangeIntToGuid")]
    partial class ChangeIntToGuid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("HRApp.Models.Employee", b =>
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

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
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
                            LastName = "Mulvey",
                            Salary = "£34886.72"
                        },
                        new
                        {
                            Id = 3,
                            Department = "Product Management",
                            Email = "rquadrio2@wufoo.com",
                            FirstName = "Ronni",
                            Gender = "Male",
                            LastName = "Quadrio",
                            Salary = "£56447.51"
                        },
                        new
                        {
                            Id = 4,
                            Department = "Services",
                            Email = "cbroseman3@cam.ac.uk",
                            FirstName = "Chery",
                            Gender = "Female",
                            LastName = "Broseman",
                            Salary = "£42535.58"
                        },
                        new
                        {
                            Id = 5,
                            Department = "Human Resources",
                            Email = "lbeadnall4@livejournal.com",
                            FirstName = "Lelia",
                            Gender = "Female",
                            LastName = "Beadnall",
                            Salary = "£57500.48"
                        },
                        new
                        {
                            Id = 6,
                            Department = "Legal",
                            Email = "aeslinger5@cam.ac.uk",
                            FirstName = "Archibold",
                            Gender = "Male",
                            LastName = "Eslinger",
                            Salary = "£32775.63"
                        },
                        new
                        {
                            Id = 7,
                            Department = "Research and Development",
                            Email = "vmacarthur6@desdev.cn",
                            FirstName = "Vida",
                            Gender = "Female",
                            LastName = "MacArthur",
                            Salary = "£58116.07"
                        },
                        new
                        {
                            Id = 8,
                            Department = "Training",
                            Email = "orapin7@guardian.co.uk",
                            FirstName = "Odey",
                            Gender = "Male",
                            LastName = "Rapin",
                            Salary = "£32643.37"
                        },
                        new
                        {
                            Id = 9,
                            Department = "Support",
                            Email = "jcottem8@fotki.com",
                            FirstName = "Jacquenetta",
                            Gender = "Female",
                            LastName = "Cottem",
                            Salary = "£20902.55"
                        },
                        new
                        {
                            Id = 10,
                            Department = "Accounting",
                            Email = "amullaly9@toplist.cz",
                            FirstName = "Arny",
                            Gender = "Male",
                            LastName = "Mullaly",
                            Salary = "£53201.85"
                        });
                });

            modelBuilder.Entity("HRApp.Models.TimeTrackingEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("HoursWorked")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TimeTrackingEntries");
                });
#pragma warning restore 612, 618
        }
    }
}