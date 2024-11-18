using HRApp.Models;
using HRApp.Repositories.Employee;

namespace HRApp.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employees>> GetEmployeesAsync()
    {
        return await _employeeRepository.GetAllEmployeesAsync();
    }

    Task<Employees?> IEmployeeService.GetEmployeeAsync(int id)
    {
        return GetEmployeeAsync(id);
    }

    Task IEmployeeService.CreateEmployeeAsync(Employees employee)
    {
        return CreateEmployeeAsync(employee);
    }

    Task IEmployeeService.UpdateEmployeeAsync(Employees employee)
    {
        return UpdateEmployeeAsync(employee);
    }

    Task IEmployeeService.DeleteEmployeeAsync(Employees employee)
    {
        return DeleteEmployeeAsync(employee);
    }

    Task<List<Employees>> IEmployeeService.GetEmployeesAsync()
    {
        return GetEmployeesAsync();
    }

    public async Task<Employees?> GetEmployeeAsync(int id)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(id);
    }

    public async Task CreateEmployeeAsync(Employees employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
    }

    public async Task UpdateEmployeeAsync(Employees employee)
    {
        await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(Employees employee)
    {
        await _employeeRepository.DeleteEmployeeAsync(employee);
    }
}