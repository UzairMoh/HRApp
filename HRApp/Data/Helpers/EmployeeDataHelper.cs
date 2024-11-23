using HRApp.Models;
using HRApp.Models.Enums.Employee;

namespace HRApp.Data.Helpers;

public static class EmployeeDataHelper
{
    private static readonly Random Random = new(123);

    public static (ContractType contractType, BenefitsPackage benefits, int hours, bool overtime, int vacation) 
        GetEmployeeDetails(Department department, decimal salary)
    {
        var typeRoll = Random.NextDouble();
            
        var contractType = department switch
        {
            Department.Engineering when salary > 60000 => ContractType.Permanent,
            Department.ProductManagement when salary > 60000 => ContractType.Permanent,
            _ when typeRoll < 0.7 => ContractType.Permanent,
            _ when typeRoll < 0.85 => ContractType.FixedTerm,
            _ when typeRoll < 0.95 => ContractType.Temporary,
            _ => ContractType.Apprenticeship
        };

        return contractType switch
        {
            ContractType.Permanent => (
                ContractType.Permanent,
                BenefitsPackage.Standard,
                40,
                true,
                25 + Random.Next(0, 6) // 25-30 days
            ),
            ContractType.FixedTerm => (
                ContractType.FixedTerm,
                BenefitsPackage.PartTime,
                20 + Random.Next(0, 11), // 20-30 hours
                true,
                12 + Random.Next(0, 4) // 12-15 days
            ),
            ContractType.Temporary => (
                ContractType.Temporary,
                BenefitsPackage.Contractor,
                40,
                false,
                0
            ),
            ContractType.Apprenticeship => (
                ContractType.Apprenticeship,
                BenefitsPackage.Intern,
                40,
                false,
                10
            ),
            _ => throw new ArgumentException("Invalid contract type")
        };
    }

    public static Employees CreateEmployee(
        int id, 
        string firstName, 
        string lastName, 
        string email, 
        Gender gender, 
        Department department, 
        decimal salary, 
        DateTime joinDate, 
        DateTime? leaveDate = null)
    {
        var (contractType, benefits, hours, overtime, vacation) = 
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
            ContractType = contractType,
            BenefitsPackage = benefits,
            WorkingHoursPerWeek = hours,
            IsOvertimeEligible = overtime,
            VacationDaysPerYear = vacation,
            TimeOffRequests = new List<TimeOffRequest>()
        };
    }
}