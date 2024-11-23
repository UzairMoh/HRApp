using HRApp.Models.Enums.Employee;
using HRApp.Services.Employee;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace HRApp.Pages.AdminView;

public partial class Employees
{
    [Inject] private IEmployeeService? EmployeeService { get; set; }

    private bool ShowCreate { get; set; }
    private bool ShowEdit { get; set; }
    private int EditingId { get; set; }

    // Form fields for new employee
    private string FirstName { get; set; } = string.Empty;
    private string LastName { get; set; } = string.Empty;
    private string Email { get; set; } = string.Empty;
    private Gender Gender { get; set; } = Gender.PreferNotToSay;
    private Department Department { get; set; } = Department.Engineering;
    private decimal Salary { get; set; }
    private ContractType ContractType { get; set; } = ContractType.Permanent;

    // Properties for editing
    private string EditFirstName { get; set; } = string.Empty;
    private string EditLastName { get; set; } = string.Empty;
    private string EditEmail { get; set; } = string.Empty;
    private Gender EditGender { get; set; }
    private Department EditDepartment { get; set; }
    private decimal EditSalary { get; set; }
    private ContractType EditContractType { get; set; }

    private List<Models.Employees>? OurEmployees { get; set; }
    private string ErrorMessage { get; set; } = string.Empty;

    // Filter properties
    private string SearchTerm { get; set; } = string.Empty;
    private Department? SelectedDepartment { get; set; }
    private Gender? SelectedGender { get; set; }
    private ContractType? SelectedContractType { get; set; }
    private decimal? MinSalary { get; set; }
    private decimal? MaxSalary { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ShowCreate = false;
        ShowEdit = false;
        await LoadEmployeesAsync();
    }

    private void ShowCreateForm()
    {
        ShowCreate = true;
        ResetCreateForm();
    }

    private async Task CreateNewEmployeeAsync()
    {
        try
        {
            await EmployeeService!.CreateEmployeeAsync(
                FirstName,
                LastName,
                Email,
                Gender,
                Department,
                Salary,
                ContractType
            );
            
            await LoadEmployeesAsync();
            ShowCreate = false;
            ErrorMessage = string.Empty;
        }
        catch (ValidationException ex)
        {
            ErrorMessage = ex.Message;
        }
        catch (Exception ex)
        {
            ErrorMessage = "An error occurred while creating the employee.";
            Console.WriteLine(ex);
        }
    }

    private async Task LoadEmployeesAsync()
    {
        try
        {
            OurEmployees = await EmployeeService!.GetEmployeesAsync();
            ErrorMessage = string.Empty;
        }
        catch (Exception ex)
        {
            ErrorMessage = "Failed to load employees.";
            Console.WriteLine(ex);
        }
    }

    private async Task ShowEditFormAsync(Models.Employees employee)
    {
        var employeeToEdit = await EmployeeService!.GetEmployeeAsync(employee.Id);
        if (employeeToEdit is not null)
        {
            PopulateEditForm(employeeToEdit);
            ShowEdit = true;
            EditingId = employee.Id;
            ErrorMessage = string.Empty;
        }
    }

    private async Task UpdateEmployeeAsync()
    {
        try
        {
            await EmployeeService!.UpdateEmployeeAsync(
                EditingId,
                EditFirstName,
                EditLastName,
                EditEmail,
                EditGender,
                EditDepartment,
                EditSalary,
                EditContractType
            );
            
            await LoadEmployeesAsync();
            ShowEdit = false;
            ErrorMessage = string.Empty;
        }
        catch (ValidationException ex)
        {
            ErrorMessage = ex.Message;
        }
        catch (KeyNotFoundException)
        {
            ErrorMessage = "Employee not found.";
        }
        catch (Exception ex)
        {
            ErrorMessage = "An error occurred while updating the employee.";
            Console.WriteLine(ex);
        }
    }

    private async Task DeleteEmployeeAsync(Models.Employees employee)
    {
        try
        {
            await EmployeeService!.DeleteEmployeeAsync(employee.Id);
            await LoadEmployeesAsync();
            ErrorMessage = string.Empty;
        }
        catch (Exception ex)
        {
            ErrorMessage = "Failed to delete employee.";
            Console.WriteLine(ex);
        }
    }

    private List<Models.Employees> FilteredEmployees => OurEmployees?
        .Where(e => FilterEmployee(e))
        .OrderBy(e => e.Department)
        .ThenBy(e => e.LastName)
        .ToList() ?? new List<Models.Employees>();

    private bool FilterEmployee(Models.Employees e) =>
        (string.IsNullOrEmpty(SearchTerm) || 
         $"{e.FirstName} {e.LastName} {e.Email}".Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)) &&
        (!SelectedDepartment.HasValue || e.Department == SelectedDepartment) &&
        (!SelectedGender.HasValue || e.Gender == SelectedGender) &&
        (!SelectedContractType.HasValue || e.ContractType == SelectedContractType) &&
        (!MinSalary.HasValue || e.Salary >= MinSalary) &&
        (!MaxSalary.HasValue || e.Salary <= MaxSalary);

    private void ResetFilters()
    {
        SearchTerm = string.Empty;
        SelectedDepartment = null;
        SelectedGender = null;
        SelectedContractType = null;
        MinSalary = null;
        MaxSalary = null;
    }

    private void CancelEdit()
    {
        ShowEdit = false;
        ResetEditForm();
        ErrorMessage = string.Empty;
    }

    private void ResetCreateForm()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Gender = Gender.PreferNotToSay;
        Department = Department.Engineering;
        Salary = 0;
        ContractType = ContractType.Permanent;
        ErrorMessage = string.Empty;
    }

    private void ResetEditForm()
    {
        EditFirstName = string.Empty;
        EditLastName = string.Empty;
        EditEmail = string.Empty;
        EditGender = Gender.PreferNotToSay;
        EditDepartment = Department.Engineering;
        EditSalary = 0;
        EditContractType = ContractType.Permanent;
    }

    private void PopulateEditForm(Models.Employees employee)
    {
        EditFirstName = employee.FirstName;
        EditLastName = employee.LastName;
        EditEmail = employee.Email;
        EditGender = employee.Gender;
        EditDepartment = employee.Department;
        EditSalary = employee.Salary;
        EditContractType = employee.ContractType;
    }

    // Helper methods for dropdowns
    private static IEnumerable<Gender> GetGenderOptions() => 
        Enum.GetValues<Gender>();

    private static IEnumerable<Department> GetDepartmentOptions() => 
        Enum.GetValues<Department>();

    private static IEnumerable<ContractType> GetContractTypeOptions() => 
        Enum.GetValues<ContractType>();

    private static string FormatSalary(decimal salary) => 
        $"£{salary:N2}";
}