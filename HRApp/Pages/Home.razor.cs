using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using HRApp.Services;
using HRApp.Models;

namespace HRApp.Pages;

public partial class Home : ComponentBase
{
    [Inject] public IEmployeeService EmployeeService { get; set; } = null!;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    [Inject] public TokenProvider TokenProvider { get; set; } = null!;

    private int TotalEmployees { get; set; }
    private int TotalMaleEmployees { get; set; }
    private int TotalFemaleEmployees { get; set; }
    private Dictionary<string, int> EmployeesByDepartment { get; set; } = new();

    private bool _isChartLoaded;

    protected override async Task OnInitializedAsync()
    {
        var employees = await EmployeeService.GetEmployeesAsync();

        TotalEmployees = employees.Count;
        TotalMaleEmployees = employees.Count(e => e.Gender == "Male");
        TotalFemaleEmployees = employees.Count(e => e.Gender == "Female");
        EmployeesByDepartment = employees
            .GroupBy(e => e.Department)
            .ToDictionary(g => g.Key!, g => g.Count());
        
        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && !_isChartLoaded)
        {
            await LoadModule();
            await LoadDepartmentChart();
            _isChartLoaded = true;
        }
    }

    private async Task LoadModule()
    {
        await JsRuntime.InvokeVoidAsync("import", "./Pages/Home.razor.js");
    }

    private async Task LoadDepartmentChart()
    {
        var departmentLabels = EmployeesByDepartment.Keys.ToArray();
        var departmentCounts = EmployeesByDepartment.Values.ToArray();

        await JsRuntime.InvokeVoidAsync("renderDepartmentChart", departmentLabels, departmentCounts);
    }
}