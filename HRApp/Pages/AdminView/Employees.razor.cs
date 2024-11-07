using HRApp.Services.Employee;
using Microsoft.AspNetCore.Components;

namespace HRApp.Pages.AdminView;

public partial class Employees
{
    [Inject] private IEmployeeService? EmployeeService { get; set; }

    private bool ShowCreate { get; set; }
    private bool ShowEdit { get; set; }
    public int EditingId { get; set; }

    private Models.Employees? NewEmployee { get; set; }
    private Models.Employees? EmployeeToUpdate { get; set; }
    private List<Models.Employees>? OurEmployees { get; set; }

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
        NewEmployee = new Models.Employees();
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

    public async Task ShowEditFormAsync(Models.Employees employees)
    {
        EmployeeToUpdate = await EmployeeService!.GetEmployeeAsync(employees.Id);
        if (EmployeeToUpdate is not null)
        {
            ShowEdit = true;
            EditingId = employees.Id;
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

    public async Task DeleteEmployeeAsync(Models.Employees employees)
    {
        await EmployeeService!.DeleteEmployeeAsync(employees);
        await LoadEmployeesAsync();
    }

    private List<Models.Employees> FilteredEmployees => OurEmployees?
        .Where(e => (string.IsNullOrEmpty(_searchTerm) || $"{e.FirstName} {e.LastName}".Contains(_searchTerm, StringComparison.OrdinalIgnoreCase)) &&
                    (string.IsNullOrEmpty(_selectedDepartment) || e.Department == _selectedDepartment) &&
                    (string.IsNullOrEmpty(_selectedGender) || e.Gender == _selectedGender))
        .ToList() ?? new List<Models.Employees>();

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