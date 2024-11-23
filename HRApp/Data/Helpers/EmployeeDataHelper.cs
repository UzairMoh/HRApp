// Data/Helpers/EmployeeDataHelper.cs
using HRApp.Models;
using HRApp.Models.Enums;

namespace HRApp.Data.Helpers;

public static class EmployeeDataHelper
{
    private static readonly Random Random = new(123);

    public static (EmployeeType type, string benefits, string contract, int hours, bool overtime, int vacation) 
        GetEmployeeDetails(string department, string salary)
    {
        var salaryNum = decimal.Parse(salary.Replace("£", "").Replace(",", ""));
        var typeRoll = Random.NextDouble();
            
        var employeeType = department switch
        {
            "Software Engineering" when salaryNum > 60000 => EmployeeType.FullTime,
            "Product Management" when salaryNum > 60000 => EmployeeType.FullTime,
            _ when typeRoll < 0.7 => EmployeeType.FullTime,
            _ when typeRoll < 0.85 => EmployeeType.PartTime,
            _ when typeRoll < 0.95 => EmployeeType.Contractor,
            _ => EmployeeType.Intern
        };

        return employeeType switch
        {
            EmployeeType.FullTime => (
                EmployeeType.FullTime,
                "Full Benefits Package",
                "Permanent",
                40,
                true,
                25 + Random.Next(0, 6) // 25-30 days
            ),
            EmployeeType.PartTime => (
                EmployeeType.PartTime,
                "Basic Benefits",
                "Part-Time",
                20 + Random.Next(0, 11), // 20-30 hours
                true,
                12 + Random.Next(0, 4) // 12-15 days
            ),
            EmployeeType.Contractor => (
                EmployeeType.Contractor,
                "No Benefits",
                "Fixed-Term Contract",
                40,
                false,
                0
            ),
            EmployeeType.Intern => (
                EmployeeType.Intern,
                "Basic Benefits",
                "Internship",
                40,
                false,
                10
            ),
            _ => throw new ArgumentException("Invalid employee type")
        };
    }

    public static Employees CreateEmployee(int id, string firstName, string lastName, string email, 
        string gender, string department, string salary, DateTime joinDate, DateTime? leaveDate = null)
    {
        var (type, benefits, contract, hours, overtime, vacation) = 
            GetEmployeeDetails(department, salary);

        return new Employees
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Gender = gender,
            Department = department,
            Salary = salary,
            JoinDate = joinDate,
            LeaveDate = leaveDate,
            EmployeeType = type,
            BenefitsPackage = benefits,
            ContractType = contract,
            WorkingHoursPerWeek = hours,
            IsOvertimeEligible = overtime,
            VacationDaysPerYear = vacation
        };
    }
}