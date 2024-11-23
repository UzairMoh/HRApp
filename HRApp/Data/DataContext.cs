using HRApp.Models;
using HRApp.Models.Enums.Employee;
using HRApp.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Data;

public class DataContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("EmployeeDB"));
    }

    public DbSet<Employees> Employees { get; set; } = null!;
    public DbSet<CalendarEvent> CalendarEvents { get; set; } = null!;
    public DbSet<TimeOffRequest> TimeOffRequests { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Employee table configuration
        modelBuilder.Entity<Employees>().ToTable("Employee");

        // Configure string to enum conversions
        modelBuilder.Entity<Employees>()
            .Property(e => e.Gender)
            .HasConversion<string>();

        modelBuilder.Entity<Employees>()
            .Property(e => e.Department)
            .HasConversion<string>();

        modelBuilder.Entity<Employees>()
            .Property(e => e.ContractType)
            .HasConversion<string>();

        modelBuilder.Entity<Employees>()
            .Property(e => e.BenefitsPackage)
            .HasConversion<string>();

        // Configure CalendarEvent relationships
        modelBuilder.Entity<CalendarEvent>()
            .HasOne(e => e.Employee)
            .WithMany()
            .HasForeignKey(e => e.EmployeeId)
            .IsRequired(false)  // Allow null for company-wide events
            .OnDelete(DeleteBehavior.Cascade);

        // Configure TimeOffRequest relationships
        modelBuilder.Entity<TimeOffRequest>()
            .HasOne(t => t.Employee)
            .WithMany(e => e.TimeOffRequests)
            .HasForeignKey(t => t.EmployeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        // Seed initial data
        var employees = new List<Employees>
        {
            new Employees
            {
                Id = 999,
                FirstName = "Admin",
                LastName = "Account",
                Email = "admin@hrapp.co.uk",
                Gender = Gender.PreferNotToSay,
                Department = Department.Engineering,
                Salary = 99999.99M,
                JoinDate = new DateTime(2022, 3, 14),
                ContractType = ContractType.Permanent,
                BenefitsPackage = BenefitsPackage.Executive,
                WorkingHoursPerWeek = 40,
                IsOvertimeEligible = false,
                VacationDaysPerYear = 30,
                TimeOffRequests = new List<TimeOffRequest>()
            }
        };

        // Add additional employees
        employees.Add(EmployeeDataHelper.CreateEmployee(
            1, 
            "Uzair", 
            "Mohammed", 
            "uzairmohammedpc@gmail.com", 
            Gender.Male, 
            Department.Engineering, 
            65000.00M, 
            new DateTime(2022, 3, 15)));
            
        employees.Add(EmployeeDataHelper.CreateEmployee(
            2, 
            "James", 
            "Wilson", 
            "jwilson@company.com", 
            Gender.Male, 
            Department.Engineering, 
            62000.00M, 
            new DateTime(2022, 4, 1)));

        modelBuilder.Entity<Employees>().HasData(employees);
    }
}