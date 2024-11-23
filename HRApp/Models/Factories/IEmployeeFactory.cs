using HRApp.Models.Enums.Employee;

namespace HRApp.Models.Factories;

/// <summary>
/// Interface for creating different types of employees.
/// </summary>
public interface IEmployeeFactory
{
    /// <summary>
    /// Creates a base employee with the specified parameters.
    /// </summary>
    Employees CreateEmployee(
        ContractType contractType,
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary);

    /// <summary>
    /// Creates a full-time employee with predefined configurations.
    /// </summary>
    Employees CreateFullTimeEmployee(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary);

    /// <summary>
    /// Creates a part-time employee with predefined configurations.
    /// </summary>
    Employees CreatePartTimeEmployee(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary);

    /// <summary>
    /// Creates a contractor employee with predefined configurations.
    /// </summary>
    Employees CreateContractor(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary);

    /// <summary>
    /// Creates an intern employee with predefined configurations.
    /// </summary>
    Employees CreateIntern(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary);
}