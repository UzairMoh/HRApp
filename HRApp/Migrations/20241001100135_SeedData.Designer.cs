﻿// <auto-generated />
using HRApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HRApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241001100135_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("HRApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Department")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Salary")
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
#pragma warning restore 612, 618
        }
    }
}
