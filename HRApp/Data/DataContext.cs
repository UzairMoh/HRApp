using HRApp.Models;
using HRApp.Models.Enums;
using HRApp.Data.Helpers;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Data;

public class DataContext(IConfiguration configuration) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(configuration.GetConnectionString("EmployeeDB"));
    }

    public DbSet<Employees> Employees { get; set; }
    public DbSet<CalendarEvent> CalendarEvents { get; set; }
    public DbSet<TimeOffRequest> TimeOffRequests { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Employee table configuration
        modelBuilder.Entity<Employees>().ToTable("Employee");

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

        var employees = new List<Employees>
        {
            new Employees
            {
                Id = 999,
                FirstName = "Admin",
                LastName = "Account",
                Email = "admin@hrapp.co.uk",
                Gender = "None",
                Department = "Software Engineering",
                Salary = "£999999.00",
                JoinDate = new DateTime(2022, 3, 14),
                EmployeeType = EmployeeType.FullTime,
                BenefitsPackage = "Executive Benefits Package",
                ContractType = "Permanent Executive",
                WorkingHoursPerWeek = 40,
                IsOvertimeEligible = false,
                VacationDaysPerYear = 30
            }
        };

        employees.Add(EmployeeDataHelper.CreateEmployee(1, "Uzair", "Mohammed", "uzairmohammedpc@gmail.com", 
            "Male", "Software Engineering", "£65000.00", new DateTime(2022, 3, 15)));
            
        employees.Add(EmployeeDataHelper.CreateEmployee(2, "James", "Wilson", "jwilson@company.com", 
            "Male", "Software Engineering", "£62000.00", new DateTime(2022, 4, 1)));

        modelBuilder.Entity<Employees>().HasData(employees);
    }
}