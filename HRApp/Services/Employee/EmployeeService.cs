using HRApp.Models;
using HRApp.Models.Enums.Employee;
using HRApp.Models.Factories;
using HRApp.Repositories.Employee;
using System.ComponentModel.DataAnnotations;

namespace HRApp.Services.Employee;

/// <summary>
/// Service for managing employee operations.
/// </summary>
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
    /// <returns>A list of all employees.</returns>
    public async Task<List<Employees>> GetEmployeesAsync()
    {
        return await _employeeRepository.GetAllEmployeesAsync();
    }

    /// <summary>
    /// Gets an employee by their ID.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <returns>The employee if found, null otherwise.</returns>
    public async Task<Employees?> GetEmployeeAsync(int id)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(id);
    }

    /// <summary>
    /// Creates a new employee using the factory pattern and saves to repository.
    /// </summary>
    /// <param name="firstName">The employee's first name.</param>
    /// <param name="lastName">The employee's last name.</param>
    /// <param name="email">The employee's email address.</param>
    /// <param name="gender">The employee's gender.</param>
    /// <param name="department">The employee's department.</param>
    /// <param name="salary">The employee's salary.</param>
    /// <param name="contractType">The type of contract for the employee.</param>
    /// <exception cref="ValidationException">Thrown when input validation fails.</exception>
    /// <exception cref="ArgumentException">Thrown when contract type is invalid.</exception>
    public async Task CreateEmployeeAsync(
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary,
        ContractType contractType)
    {
        ValidateEmployeeData(firstName, lastName, email, salary);

        var employee = contractType switch
        {
            ContractType.Permanent => _employeeFactory.CreateFullTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            ContractType.FixedTerm => _employeeFactory.CreatePartTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            ContractType.Temporary => _employeeFactory.CreateContractor(
                firstName, lastName, email, gender, department, salary),

            ContractType.Apprenticeship => _employeeFactory.CreateIntern(
                firstName, lastName, email, gender, department, salary),

            _ => throw new ArgumentException($"Invalid contract type: {contractType}", nameof(contractType))
        };

        await _employeeRepository.CreateEmployeeAsync(employee);
    }

    /// <summary>
    /// Updates an existing employee in the repository.
    /// </summary>
    /// <param name="id">The ID of the employee to update.</param>
    /// <param name="firstName">The updated first name.</param>
    /// <param name="lastName">The updated last name.</param>
    /// <param name="email">The updated email address.</param>
    /// <param name="gender">The updated gender.</param>
    /// <param name="department">The updated department.</param>
    /// <param name="salary">The updated salary.</param>
    /// <param name="contractType">The updated contract type.</param>
    /// <exception cref="KeyNotFoundException">Thrown when employee is not found.</exception>
    /// <exception cref="ValidationException">Thrown when input validation fails.</exception>
    /// <exception cref="ArgumentException">Thrown when contract type is invalid.</exception>
    public async Task UpdateEmployeeAsync(
        int id,
        string firstName,
        string lastName,
        string email,
        Gender gender,
        Department department,
        decimal salary,
        ContractType contractType)
    {
        ValidateEmployeeData(firstName, lastName, email, salary);

        var existingEmployee = await _employeeRepository.GetEmployeeByIdAsync(id) 
            ?? throw new KeyNotFoundException($"Employee with ID {id} not found");

        // Update basic properties
        existingEmployee.FirstName = firstName;
        existingEmployee.LastName = lastName;
        existingEmployee.Email = email;
        existingEmployee.Gender = gender;
        existingEmployee.Department = department;
        existingEmployee.Salary = salary;

        // Update type-specific properties using factory
        var newEmployee = contractType switch
        {
            ContractType.Permanent => _employeeFactory.CreateFullTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            ContractType.FixedTerm => _employeeFactory.CreatePartTimeEmployee(
                firstName, lastName, email, gender, department, salary),

            ContractType.Temporary => _employeeFactory.CreateContractor(
                firstName, lastName, email, gender, department, salary),

            ContractType.Apprenticeship => _employeeFactory.CreateIntern(
                firstName, lastName, email, gender, department, salary),

            _ => throw new ArgumentException($"Invalid contract type: {contractType}", nameof(contractType))
        };

        // Copy type-specific properties
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
    /// <param name="id">The ID of the employee to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown when employee is not found.</exception>
    public async Task DeleteEmployeeAsync(int id)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(id) 
            ?? throw new KeyNotFoundException($"Employee with ID {id} not found");
            
        await _employeeRepository.DeleteEmployeeAsync(employee);
    }

    /// <summary>
    /// Validates employee data before creation or update.
    /// </summary>
    /// <exception cref="ValidationException">Thrown when validation fails.</exception>
    private static void ValidateEmployeeData(string firstName, string lastName, string email, decimal salary)
    {
        var validationErrors = new List<string>();

        if (string.IsNullOrWhiteSpace(firstName))
            validationErrors.Add("First name is required");
        if (firstName?.Length > 50)
            validationErrors.Add("First name cannot be longer than 50 characters");

        if (string.IsNullOrWhiteSpace(lastName))
            validationErrors.Add("Last name is required");
        if (lastName?.Length > 50)
            validationErrors.Add("Last name cannot be longer than 50 characters");

        if (string.IsNullOrWhiteSpace(email))
            validationErrors.Add("Email is required");
        if (email?.Length > 100)
            validationErrors.Add("Email cannot be longer than 100 characters");
        if (!IsValidEmail(email))
            validationErrors.Add("Invalid email format");

        if (salary < 0)
            validationErrors.Add("Salary cannot be negative");

        if (validationErrors.Any())
            throw new ValidationException(string.Join(Environment.NewLine, validationErrors));
    }

    /// <summary>
    /// Validates email format.
    /// </summary>
    private static bool IsValidEmail(string? email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email!);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}