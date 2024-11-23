using HRApp.Models.Configuration;
using HRApp.Models.Enums.Employee;

namespace HRApp.Models.Factories;

/// <summary>
/// Factory for creating different types of employees with predefined configurations.
/// </summary>
public class EmployeeFactory : IEmployeeFactory
{
    /// <summary>
    /// Creates a base employee with the specified parameters.
    /// </summary>
    /// <param name="contractType">The type of contract for the employee.</param>
    /// <param name="firstName">The employee's first name.</param>
    /// <param name="lastName">The employee's last name.</param>
    /// <param name="email">The employee's email address.</param>
    /// <param name="gender">The employee's gender.</param>
    /// <param name="department">The employee's department.</param>
    /// <param name="salary">The employee's salary.</param>
    /// <returns>A new employee instance.</returns>
    public Employees CreateEmployee(
        ContractType contractType,
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary)
    {
        var employee = new Employees
        {
            ContractType = contractType,
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

    /// <summary>
    /// Creates a full-time employee with predefined configurations.
    /// </summary>
    /// <param name="firstName">The employee's first name.</param>
    /// <param name="lastName">The employee's last name.</param>
    /// <param name="email">The employee's email address.</param>
    /// <param name="gender">The employee's gender.</param>
    /// <param name="department">The employee's department.</param>
    /// <param name="salary">The employee's salary.</param>
    /// <returns>A new full-time employee instance.</returns>
    public Employees CreateFullTimeEmployee(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary)
    {
        var employee = CreateEmployee(
            ContractType.Permanent,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = BenefitsPackage.Standard;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.FullTime.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.FullTime.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.FullTime.VacationDaysPerYear;

        return employee;
    }

    /// <summary>
    /// Creates a part-time employee with predefined configurations.
    /// </summary>
    /// <param name="firstName">The employee's first name.</param>
    /// <param name="lastName">The employee's last name.</param>
    /// <param name="email">The employee's email address.</param>
    /// <param name="gender">The employee's gender.</param>
    /// <param name="department">The employee's department.</param>
    /// <param name="salary">The employee's salary.</param>
    /// <returns>A new part-time employee instance.</returns>
    public Employees CreatePartTimeEmployee(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary)
    {
        var employee = CreateEmployee(
            ContractType.FixedTerm,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = BenefitsPackage.PartTime;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.PartTime.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.PartTime.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.PartTime.VacationDaysPerYear;

        return employee;
    }

    /// <summary>
    /// Creates a contractor employee with predefined configurations.
    /// </summary>
    /// <param name="firstName">The employee's first name.</param>
    /// <param name="lastName">The employee's last name.</param>
    /// <param name="email">The employee's email address.</param>
    /// <param name="gender">The employee's gender.</param>
    /// <param name="department">The employee's department.</param>
    /// <param name="salary">The employee's salary.</param>
    /// <returns>A new contractor employee instance.</returns>
    public Employees CreateContractor(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary)
    {
        var employee = CreateEmployee(
            ContractType.Temporary,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = BenefitsPackage.Contractor;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.Contractor.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.Contractor.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.Contractor.VacationDaysPerYear;

        return employee;
    }

    /// <summary>
    /// Creates an intern employee with predefined configurations.
    /// </summary>
    /// <param name="firstName">The employee's first name.</param>
    /// <param name="lastName">The employee's last name.</param>
    /// <param name="email">The employee's email address.</param>
    /// <param name="gender">The employee's gender.</param>
    /// <param name="department">The employee's department.</param>
    /// <param name="salary">The employee's salary.</param>
    /// <returns>A new intern employee instance.</returns>
    public Employees CreateIntern(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary)
    {
        var employee = CreateEmployee(
            ContractType.Apprenticeship,
            firstName,
            lastName,
            email,
            gender,
            department,
            salary
        );

        employee.BenefitsPackage = BenefitsPackage.Intern;
        employee.WorkingHoursPerWeek = EmployeeConfigurations.Intern.WorkingHoursPerWeek;
        employee.IsOvertimeEligible = EmployeeConfigurations.Intern.IsOvertimeEligible;
        employee.VacationDaysPerYear = EmployeeConfigurations.Intern.VacationDaysPerYear;

        return employee;
    }
}