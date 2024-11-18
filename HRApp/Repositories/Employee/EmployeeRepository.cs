using HRApp.Data;
using HRApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Repositories.Employee;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _context;

    public EmployeeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Employees>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employees?> GetEmployeeByIdAsync(int id)
    {
        return await _context.Employees.FindAsync(id);
    }

    public async Task AddEmployeeAsync(Employees employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employees employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Employees employee)
    {
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}