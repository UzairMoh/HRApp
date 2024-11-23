using HRApp.Models.Configuration;
using HRApp.Models.Enums;

namespace HRApp.Models.Factories;

public class EmployeeFactory : IEmployeeFactory
{
    public Employees CreateEmployee(
        EmployeeType type,
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary)
    {
        var employee = new Employees
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Gender = gender,
            Department = department,
            Salary = salary,
            JoinDate = DateTime.Now,
            TimeOffRequests = new List<TimeOffRequest>()
        };

        return employee;
    }

    public Employees CreateFullTimeEmployee(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary)
    {
        var employee = CreateEmployee(
            EmployeeType.FullTime,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = EmployeeConfigurations.FullTime.BenefitsPackage;
        employee.ContractType = EmployeeConfigurations.FullTime.ContractType;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.FullTime.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.FullTime.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.FullTime.VacationDaysPerYear;

        return employee;
    }

    public Employees CreatePartTimeEmployee(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary)
    {
        var employee = CreateEmployee(
            EmployeeType.PartTime,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = EmployeeConfigurations.PartTime.BenefitsPackage;
        employee.ContractType = EmployeeConfigurations.PartTime.ContractType;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.PartTime.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.PartTime.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.PartTime.VacationDaysPerYear;

        return employee;
    }

    public Employees CreateContractor(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary)
    {
        var employee = CreateEmployee(
            EmployeeType.Contractor,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = EmployeeConfigurations.Contractor.BenefitsPackage;
        employee.ContractType = EmployeeConfigurations.Contractor.ContractType;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.Contractor.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.Contractor.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.Contractor.VacationDaysPerYear;

        return employee;
    }

    public Employees CreateIntern(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary)
    {
        var employee = CreateEmployee(
            EmployeeType.Intern,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = EmployeeConfigurations.Intern.BenefitsPackage;
        employee.ContractType = EmployeeConfigurations.Intern.ContractType;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.Intern.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.Intern.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.Intern.VacationDaysPerYear;

        return employee;
    }
}