using HRApp.Models;
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

        modelBuilder.Entity<Employees>().HasData(
            new Employees
            {
                Id = 999, FirstName = "Admin", LastName = "Account", Email = "admin@hrapp.co.uk",
                Gender = "None", Department = "Software Engineering", Salary = "£999999.00",
                JoinDate = new DateTime(2022, 3, 14)
            },
            new Employees
            {
                Id = 1, FirstName = "Uzair", LastName = "Mohammed", Email = "uzairmohammedpc@gmail.com",
                Gender = "Male", Department = "Software Engineering", Salary = "£65000.00",
                JoinDate = new DateTime(2022, 3, 15)
            },
            new Employees
            {
                Id = 2, FirstName = "James", LastName = "Wilson", Email = "jwilson@company.com",
                Gender = "Male", Department = "Software Engineering", Salary = "£62000.00",
                JoinDate = new DateTime(2022, 4, 1)
            },
            new Employees
            {
                Id = 3, FirstName = "Emily", LastName = "Patel", Email = "epatel@company.com",
                Gender = "Female", Department = "Product Management", Salary = "£68000.00",
                JoinDate = new DateTime(2022, 6, 15)
            },
            new Employees
            {
                Id = 4, FirstName = "Michael", LastName = "Thompson", Email = "mthompson@company.com",
                Gender = "Male", Department = "Sales", Salary = "£55000.00",
                JoinDate = new DateTime(2022, 7, 1),
                LeaveDate = new DateTime(2023, 12, 31)
            },
            new Employees
            {
                Id = 5, FirstName = "Jessica", LastName = "Kumar", Email = "jkumar@company.com",
                Gender = "Female", Department = "Marketing", Salary = "£52000.00",
                JoinDate = new DateTime(2022, 9, 1)
            },
            new Employees
            {
                Id = 6, FirstName = "David", LastName = "Zhang", Email = "dzhang@company.com",
                Gender = "Male", Department = "Software Engineering", Salary = "£63000.00",
                JoinDate = new DateTime(2022, 10, 15)
            },
            new Employees
            {
                Id = 7, FirstName = "Lisa", LastName = "Martinez", Email = "lmartinez@company.com",
                Gender = "Female", Department = "Human Resources", Salary = "£48000.00",
                JoinDate = new DateTime(2023, 1, 10)
            },
            new Employees
            {
                Id = 8, FirstName = "Robert", LastName = "Singh", Email = "rsingh@company.com",
                Gender = "Male", Department = "Software Engineering", Salary = "£64000.00",
                JoinDate = new DateTime(2023, 2, 15),
                LeaveDate = new DateTime(2024, 2, 28)
            },
            new Employees
            {
                Id = 9, FirstName = "Michelle", LastName = "Lee", Email = "mlee@company.com",
                Gender = "Female", Department = "Product Management", Salary = "£66000.00",
                JoinDate = new DateTime(2023, 3, 1)
            },
            new Employees
            {
                Id = 10, FirstName = "William", LastName = "Brown", Email = "wbrown@company.com",
                Gender = "Male", Department = "Sales", Salary = "£54000.00",
                JoinDate = new DateTime(2023, 4, 15)
            },
            new Employees
            {
                Id = 11, FirstName = "Emma", LastName = "Johnson", Email = "ejohnson@company.com",
                Gender = "Female", Department = "Software Engineering", Salary = "£61000.00",
                JoinDate = new DateTime(2023, 6, 1)
            },
            new Employees
            {
                Id = 12, FirstName = "Daniel", LastName = "Kim", Email = "dkim@company.com",
                Gender = "Male", Department = "Marketing", Salary = "£51000.00",
                JoinDate = new DateTime(2023, 7, 15),
                LeaveDate = new DateTime(2024, 1, 31)
            },
            new Employees
            {
                Id = 13, FirstName = "Rachel", LastName = "Garcia", Email = "rgarcia@company.com",
                Gender = "Female", Department = "Software Engineering", Salary = "£63000.00",
                JoinDate = new DateTime(2023, 9, 1)
            },
            new Employees
            {
                Id = 14, FirstName = "Thomas", LastName = "Anderson", Email = "tanderson@company.com",
                Gender = "Male", Department = "Product Management", Salary = "£67000.00",
                JoinDate = new DateTime(2023, 10, 15)
            },
            new Employees
            {
                Id = 15, FirstName = "Sophia", LastName = "Wang", Email = "swang@company.com",
                Gender = "Female", Department = "Software Engineering", Salary = "£62000.00",
                JoinDate = new DateTime(2023, 11, 1)
            },
            new Employees
            {
                Id = 16, FirstName = "Kevin", LastName = "Taylor", Email = "ktaylor@company.com",
                Gender = "Male", Department = "Sales", Salary = "£56000.00",
                JoinDate = new DateTime(2024, 1, 15)
            },
            new Employees
            {
                Id = 17, FirstName = "Anna", LastName = "Rodriguez", Email = "arodriguez@company.com",
                Gender = "Female", Department = "Marketing", Salary = "£53000.00",
                JoinDate = new DateTime(2024, 2, 1)
            },
            new Employees
            {
                Id = 18, FirstName = "Christopher", LastName = "Gupta", Email = "cgupta@company.com",
                Gender = "Male", Department = "Software Engineering", Salary = "£65000.00",
                JoinDate = new DateTime(2024, 3, 15),
                LeaveDate = new DateTime(2024, 9, 30)
            },
            new Employees
            {
                Id = 19, FirstName = "Alexandra", LastName = "Nguyen", Email = "anguyen@company.com",
                Gender = "Female", Department = "Human Resources", Salary = "£49000.00",
                JoinDate = new DateTime(2024, 4, 1)
            },
            new Employees
            {
                Id = 20, FirstName = "Ryan", LastName = "White", Email = "rwhite@company.com",
                Gender = "Male", Department = "Software Engineering", Salary = "£64000.00",
                JoinDate = new DateTime(2024, 5, 15)
            },
            new Employees
            {
                Id = 21, FirstName = "Isabella", LastName = "Santos", Email = "isantos@company.com",
                Gender = "Female", Department = "Product Management", Salary = "£65000.00",
                JoinDate = new DateTime(2024, 6, 1)
            },
            new Employees
            {
                Id = 22, FirstName = "Jonathan", LastName = "Park", Email = "jpark@company.com",
                Gender = "Male", Department = "Software Engineering", Salary = "£63000.00",
                JoinDate = new DateTime(2024, 7, 15)
            },
            new Employees
            {
                Id = 23, FirstName = "Maria", LastName = "Collins", Email = "mcollins@company.com",
                Gender = "Female", Department = "Marketing", Salary = "£52000.00",
                JoinDate = new DateTime(2024, 8, 1)
            },
            new Employees
            {
                Id = 24, FirstName = "Andrew", LastName = "Murphy", Email = "amurphy@company.com",
                Gender = "Male", Department = "Sales", Salary = "£55000.00",
                JoinDate = new DateTime(2024, 9, 15)
            },
            new Employees
            {
                Id = 25, FirstName = "Julia", LastName = "Cohen", Email = "jcohen@company.com",
                Gender = "Female", Department = "Software Engineering", Salary = "£61000.00",
                JoinDate = new DateTime(2024, 10, 1)
            }
        );
    }
}