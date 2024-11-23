using HRApp.Models;
using HRApp.Models.Enums;
using HRApp.Services.Employee;
using Microsoft.AspNetCore.Components;

namespace HRApp.Pages.AdminView;

public partial class Employees
{
    [Inject] private IEmployeeService? EmployeeService { get; set; }

    private bool ShowCreate { get; set; }
    private bool ShowEdit { get; set; }
    public int EditingId { get; set; }

    // Form fields for new employee
    private string FirstName { get; set; } = string.Empty;
    private string LastName { get; set; } = string.Empty;
    private string Email { get; set; } = string.Empty;
    private string Gender { get; set; } = string.Empty;
    private string Department { get; set; } = string.Empty;
    private string Salary { get; set; } = string.Empty;
    private EmployeeType EmployeeType { get; set; }

    // Properties for editing
    private string EditFirstName { get; set; } = string.Empty;
    private string EditLastName { get; set; } = string.Empty;
    private string EditEmail { get; set; } = string.Empty;
    private string EditGender { get; set; } = string.Empty;
    private string EditDepartment { get; set; } = string.Empty;
    private string EditSalary { get; set; } = string.Empty;
    private EmployeeType EditEmployeeType { get; set; }

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
        // Reset form fields
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Gender = string.Empty;
        Department = string.Empty;
        Salary = string.Empty;
        EmployeeType = EmployeeType.FullTime; // Default value
    }

    public async Task CreateNewEmployeeAsync()
    {
        await EmployeeService!.CreateEmployeeAsync(
            FirstName,
            LastName,
            Email,
            Gender,
            Department,
            Salary,
            EmployeeType
        );
        
        await LoadEmployeesAsync();
        ShowCreate = false;
    }

    private async Task LoadEmployeesAsync()
    {
        OurEmployees = await EmployeeService!.GetEmployeesAsync();
    }

    public async Task ShowEditFormAsync(Models.Employees employee)
    {
        var employeeToEdit = await EmployeeService!.GetEmployeeAsync(employee.Id);
        if (employeeToEdit is not null)
        {
            // Populate edit fields
            EditFirstName = employeeToEdit.FirstName ?? string.Empty;
            EditLastName = employeeToEdit.LastName ?? string.Empty;
            EditEmail = employeeToEdit.Email ?? string.Empty;
            EditGender = employeeToEdit.Gender ?? string.Empty;
            EditDepartment = employeeToEdit.Department ?? string.Empty;
            EditSalary = employeeToEdit.Salary ?? string.Empty;
            EditEmployeeType = employeeToEdit.EmployeeType;
            
            ShowEdit = true;
            EditingId = employee.Id;
        }
    }

    public async Task UpdateEmployeeAsync()
    {
        await EmployeeService!.UpdateEmployeeAsync(
            EditingId,
            EditFirstName,
            EditLastName,
            EditEmail,
            EditGender,
            EditDepartment,
            EditSalary,
            EditEmployeeType
        );
        
        await LoadEmployeesAsync();
        ShowEdit = false;
    }

    public async Task DeleteEmployeeAsync(Models.Employees employee)
    {
        await EmployeeService!.DeleteEmployeeAsync(employee.Id);
        await LoadEmployeesAsync();
    }

    private List<Models.Employees> FilteredEmployees => OurEmployees?
        .Where(e => (string.IsNullOrEmpty(_searchTerm) || 
                    $"{e.FirstName} {e.LastName}".Contains(_searchTerm, StringComparison.OrdinalIgnoreCase)) &&
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
        // Reset edit fields
        EditFirstName = string.Empty;
        EditLastName = string.Empty;
        EditEmail = string.Empty;
        EditGender = string.Empty;
        EditDepartment = string.Empty;
        EditSalary = string.Empty;
        EditEmployeeType = EmployeeType.FullTime;
    }

    // Helper method to get employee type names for dropdown
    private IEnumerable<EmployeeType> GetEmployeeTypes()
    {
        return Enum.GetValues<EmployeeType>();
    }
}