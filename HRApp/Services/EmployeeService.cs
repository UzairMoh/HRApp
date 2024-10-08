using HRApp.Data;
using HRApp.Models;
using HRApp.Repositories;

namespace HRApp.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<List<Employee>> GetEmployeesAsync()
    {
        return await _employeeRepository.GetAllEmployeesAsync();
    }

    Task<Employee?> IEmployeeService.GetEmployeeAsync(int id)
    {
        return GetEmployeeAsync(id);
    }

    Task IEmployeeService.CreateEmployeeAsync(Employee employee)
    {
        return CreateEmployeeAsync(employee);
    }

    Task IEmployeeService.UpdateEmployeeAsync(Employee employee)
    {
        return UpdateEmployeeAsync(employee);
    }

    Task IEmployeeService.DeleteEmployeeAsync(Employee employee)
    {
        return DeleteEmployeeAsync(employee);
    }

    Task<List<Employee>> IEmployeeService.GetEmployeesAsync()
    {
        return GetEmployeesAsync();
    }

    public async Task<Employee?> GetEmployeeAsync(int id)
    {
        return await _employeeRepository.GetEmployeeByIdAsync(id);
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        await _employeeRepository.AddEmployeeAsync(employee);
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        await _employeeRepository.UpdateEmployeeAsync(employee);
    }

    public async Task DeleteEmployeeAsync(Employee employee)
    {
        await _employeeRepository.DeleteEmployeeAsync(employee);
    }
}