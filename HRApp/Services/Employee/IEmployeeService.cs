using HRApp.Models;
using HRApp.Models.Enums.Employee;

namespace HRApp.Services.Employee;

/// <summary>
/// Interface for employee management operations.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Gets all employees.
    /// </summary>
    Task<List<Employees>> GetEmployeesAsync();

    /// <summary>
    /// Gets an employee by ID.
    /// </summary>
    Task<Employees?> GetEmployeeAsync(int id);

    /// <summary>
    /// Creates a new employee.
    /// </summary>
    Task CreateEmployeeAsync(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary,
        ContractType contractType);

    /// <summary>
    /// Updates an existing employee.
    /// </summary>
    Task UpdateEmployeeAsync(
        int id,
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary,
        ContractType contractType);

    /// <summary>
    /// Deletes an employee.
    /// </summary>
    Task DeleteEmployeeAsync(int id);
}