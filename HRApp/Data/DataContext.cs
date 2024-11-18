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
                Id = 1, FirstName = "Evaleen", LastName = "Bissill", Email = "ebissill0@mac.com",
                Gender = "Female", Department = "Engineering", Salary = "£28110.63"
            },
            new Employees
            {
                Id = 2, FirstName = "Chrisy", LastName = "Mulvey", Email = "cmulvey1@abc.net.au",
                Gender = "Male", Department = "Accounting", Salary = "£34886.72"
            },
            new Employees
            {
                Id = 3, FirstName = "Ronni", LastName = "Quadrio", Email = "rquadrio2@wufoo.com",
                Gender = "Male", Department = "Product Management", Salary = "£56447.51"
            },
            new Employees
            {
                Id = 4, FirstName = "Chery", LastName = "Broseman", Email = "cbroseman3@cam.ac.uk",
                Gender = "Female", Department = "Services", Salary = "£42535.58"
            },
            new Employees
            {
                Id = 5, FirstName = "Lelia", LastName = "Beadnall", Email = "lbeadnall4@livejournal.com",
                Gender = "Female", Department = "Human Resources", Salary = "£57500.48"
            },
            new Employees
            {
                Id = 6, FirstName = "Archibold", LastName = "Eslinger", Email = "aeslinger5@cam.ac.uk",
                Gender = "Male", Department = "Legal", Salary = "£32775.63"
            },
            new Employees
            {
                Id = 7, FirstName = "Vida", LastName = "MacArthur", Email = "vmacarthur6@desdev.cn",
                Gender = "Female", Department = "Research and Development", Salary = "£58116.07"
            },
            new Employees
            {
                Id = 8, FirstName = "Odey", LastName = "Rapin", Email = "orapin7@guardian.co.uk",
                Gender = "Male", Department = "Training", Salary = "£32643.37"
            },
            new Employees
            {
                Id = 9, FirstName = "Jacquenetta", LastName = "Cottem", Email = "jcottem8@fotki.com",
                Gender = "Female", Department = "Support", Salary = "£20902.55"
            },
            new Employees
            {
                Id = 10, FirstName = "Arny", LastName = "Mullaly", Email = "amullaly9@toplist.cz",
                Gender = "Male", Department = "Accounting", Salary = "£53201.85"
            }
        );
    }
}