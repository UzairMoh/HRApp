using HRApp.Models;

namespace HRApp.Repositories.Employee;

public interface IEmployeeRepository
{
    Task<List<Employees>> GetAllEmployeesAsync();
    Task<Employees?> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employees employee);
    Task UpdateEmployeeAsync(Employees employee);
    Task DeleteEmployeeAsync(Employees employee);
}