using HRApp.Models;
using HRApp.Models.Enums;
using HRApp.Models.Factories;
using HRApp.Repositories.Employee;

namespace HRApp.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmployeeFactory _employeeFactory;

    public EmployeeService(
        IEmployeeRepository employeeRepository,
        IEmployeeFactory employeeFactory)
    {
        _employeeRepository = employeeRepository;
        _employeeFactory = employeeFactory;
    }

    /// <summary>
    /// Gets all employees from the repository.
    /// </summary>
    public async Task<List<Employees>> GetEmployeesAsync()
    {
        return await _employeeRepository.GetAllEmployeesAsync();
    }

    /// <summary>
    /// Gets an employee by their ID.
    /// </summary>
    public async Task<Employees?> GetEmployeeAsync(int id)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(id);
    }

    /// <summary>
    /// Creates a new employee using the factory pattern and saves to repository.
    /// </summary>
    public async Task CreateEmployeeAsync(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary,
        EmployeeType employeeType)
    {
        var employee = employeeType switch
        {
            EmployeeType.FullTime => _employeeFactory.CreateFullTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            EmployeeType.PartTime => _employeeFactory.CreatePartTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            EmployeeType.Contractor => _employeeFactory.CreateContractor(
                firstName, lastName, email, gender, department, salary),

            EmployeeType.Intern => _employeeFactory.CreateIntern(
                firstName, lastName, email, gender, department, salary),

            _ => throw new ArgumentException("Invalid employee type", nameof(employeeType))
        };

        await _employeeRepository.CreateEmployeeAsync(employee);
    }

    /// <summary>
    /// Updates an existing employee in the repository.
    /// </summary>
    public async Task UpdateEmployeeAsync(
        int id,
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary,
        EmployeeType employeeType)
    {
        // Get existing employee
        var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id) 
            ?? throw new KeyNotFoundException($"Employee with ID {id} not found");

        // Update properties
        existingEmployee.FirstName = firstName;
        existingEmployee.LastName = lastName;
        existingEmployee.Email = email;
        existingEmployee.Gender = gender;
        existingEmployee.Department = department;
        existingEmployee.Salary = salary;

        // Update type-specific properties using factory
        var newEmployee = employeeType switch
        {
            EmployeeType.FullTime => _employeeFactory.CreateFullTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            EmployeeType.PartTime => _employeeFactory.CreatePartTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            EmployeeType.Contractor => _employeeFactory.CreateContractor(
                firstName, lastName, email, gender, department, salary),

            EmployeeType.Intern => _employeeFactory.CreateIntern(
                firstName, lastName, email, gender, department, salary),

            _ => throw new ArgumentException("Invalid employee type", nameof(employeeType))
        };

        // Copy type-specific properties
        existingEmployee.EmployeeType = newEmployee.EmployeeType;
        existingEmployee.BenefitsPackage = newEmployee.BenefitsPackage;
        existingEmployee.ContractType = newEmployee.ContractType;
        existingEmployee.WorkingHoursPerWeek = newEmployee.WorkingHoursPerWeek;
        existingEmployee.IsOvertimeEligible = newEmployee.IsOvertimeEligible;
        existingEmployee.VacationDaysPerYear = newEmployee.VacationDaysPerYear;

        await _employeeRepository.UpdateEmployeeAsync(existingEmployee);
    }

    /// <summary>
    /// Deletes an employee from the repository.
    /// </summary>
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id) 
            ?? throw new KeyNotFoundException($"Employee with ID {id} not found");
            
        await _employeeRepository.DeleteEmployeeAsync(employee);
    }
}