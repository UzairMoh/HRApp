using HRApp.Models;

namespace HRApp.Services.Employee;

public interface IEmployeeService
{
    Task<List<Employees>> GetEmployeesAsync();
    Task<Employees?> GetEmployeeAsync(int id);
    Task CreateEmployeeAsync(Employees employee);
    Task UpdateEmployeeAsync(Employees employee);
    Task DeleteEmployeeAsync(Employees employee);
}