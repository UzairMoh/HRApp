using HRApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Data;

public class EmployeeDataContext(IConfiguration configuration) : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(configuration.GetConnectionString("EmployeeDB"));
    }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employee");

        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1, FirstName = "Evaleen", LastName = "Bissill", Email = "ebissill0@mac.com",
                Gender = "Female", Department = "Engineering", Salary = "£28110.63"
            },
            new Employee
            {
                Id = 2, FirstName = "Chrisy", LastName = "Mulvey", Email = "cmulvey1@abc.net.au",
                Gender = "Male", Department = "Accounting", Salary = "£34886.72"
            },
            new Employee
            {
                Id = 3, FirstName = "Ronni", LastName = "Quadrio", Email = "rquadrio2@wufoo.com",
                Gender = "Male", Department = "Product Management", Salary = "£56447.51"
            },
            new Employee
            {
                Id = 4, FirstName = "Chery", LastName = "Broseman", Email = "cbroseman3@cam.ac.uk",
                Gender = "Female", Department = "Services", Salary = "£42535.58"
            },
            new Employee
            {
                Id = 5, FirstName = "Lelia", LastName = "Beadnall", Email = "lbeadnall4@livejournal.com",
                Gender = "Female", Department = "Human Resources", Salary = "£57500.48"
            },
            new Employee
            {
                Id = 6, FirstName = "Archibold", LastName = "Eslinger", Email = "aeslinger5@cam.ac.uk",
                Gender = "Male", Department = "Legal", Salary = "£32775.63"
            },
            new Employee
            {
                Id = 7, FirstName = "Vida", LastName = "MacArthur", Email = "vmacarthur6@desdev.cn",
                Gender = "Female", Department = "Research and Development", Salary = "£58116.07"
            },
            new Employee
            {
                Id = 8, FirstName = "Odey", LastName = "Rapin", Email = "orapin7@guardian.co.uk",
                Gender = "Male", Department = "Training", Salary = "£32643.37"
            },
            new Employee
            {
                Id = 9, FirstName = "Jacquenetta", LastName = "Cottem", Email = "jcottem8@fotki.com",
                Gender = "Female", Department = "Support", Salary = "£20902.55"
            },
            new Employee
            {
                Id = 10, FirstName = "Arny", LastName = "Mullaly", Email = "amullaly9@toplist.cz",
                Gender = "Male", Department = "Accounting", Salary = "£53201.85"
            }
        );
    }
}