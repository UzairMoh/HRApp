using HRApp.Models;
using HRApp.Models.Enums;

namespace HRApp.Services.Employee;

public interface IEmployeeService
{
    Task<List<Employees>> GetEmployeesAsync();
    Task<Employees?> GetEmployeeAsync(int id);
    Task CreateEmployeeAsync(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary,
        EmployeeType employeeType);
    Task UpdateEmployeeAsync(
        int id,
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary,
        EmployeeType employeeType);
    Task DeleteEmployeeAsync(int id);
}