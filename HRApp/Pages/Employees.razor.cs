using HRApp.Models;
using HRApp.Services;
using Microsoft.AspNetCore.Components;

namespace HRApp.Pages;

public partial class Employees
{
    [Inject] private IEmployeeService? EmployeeService { get; set; }

    private bool ShowCreate { get; set; }
    private bool ShowEdit { get; set; }
    public int EditingId { get; set; }

    private Employee? NewEmployee { get; set; }
    private Employee? EmployeeToUpdate { get; set; }
    private List<Employee>? OurEmployees { get; set; }

    private string _searchTerm = string.Empty;
    private string _selectedDepartment = string.Empty;
    private string _selectedGender = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        ShowCreate = false;
        ShowEdit = false;
        await LoadEmployeesAsync();
    }

    public void ShowCreateForm()
    {
        ShowCreate = true;
        NewEmployee = new Employee();
    }

    public async Task CreateNewEmployeeAsync()
    {
        if (NewEmployee is not null)
        {
            await EmployeeService!.CreateEmployeeAsync(NewEmployee);
            await LoadEmployeesAsync();
        }

        ShowCreate = false;
    }

    private async Task LoadEmployeesAsync()
    {
        OurEmployees = await EmployeeService!.GetEmployeesAsync();
    }

    public async Task ShowEditFormAsync(Employee employee)
    {
        EmployeeToUpdate = await EmployeeService!.GetEmployeeAsync(employee.Id);
        if (EmployeeToUpdate is not null)
        {
            ShowEdit = true;
            EditingId = employee.Id;
        }
    }

    public async Task UpdateEmployeeAsync()
    {
        if (EmployeeToUpdate is not null)
        {
            await EmployeeService!.UpdateEmployeeAsync(EmployeeToUpdate);
            await LoadEmployeesAsync();
        }

        ShowEdit = false;
    }

    public async Task DeleteEmployeeAsync(Employee employee)
    {
        await EmployeeService!.DeleteEmployeeAsync(employee);
        await LoadEmployeesAsync();
    }

    private List<Employee> FilteredEmployees => OurEmployees?
        .Where(e => (string.IsNullOrEmpty(_searchTerm) || $"{e.FirstName} {e.LastName}".Contains(_searchTerm, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(_selectedDepartment) || e.Department == _selectedDepartment) &&
                    (string.IsNullOrEmpty(_selectedGender) || e.Gender == _selectedGender))
        .ToList() ?? new List<Employee>();

    private void FilterEmployees(string term)
    {
        _searchTerm = term;
    }

    private void FilterByDepartment(string department)
    {
        _selectedDepartment = department;
    }

    private void FilterByGender(string gender)
    {
        _selectedGender = gender;
    }

    private void CancelEdit()
    {
        ShowEdit = false;
        EmployeeToUpdate = null;
    }
}