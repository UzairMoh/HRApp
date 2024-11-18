using HRApp.Models;
using HRApp.Services.Employee;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HRApp.Pages.AdminView;

public partial class AdminDashboard : ComponentBase
{
    [Inject] public IEmployeeService EmployeeService { get; set; } = null!;

    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    [Inject] public TokenProvider TokenProvider { get; set; } = null!;

    private int TotalEmployees { get; set; }
    private int TotalMaleEmployees { get; set; }
    private int TotalFemaleEmployees { get; set; }
    private Dictionary<string, int> EmployeesByDepartment { get; set; } = new();

    private Dictionary<string, int> MonthlyJoins { get; set; } = new();

    private Dictionary<string, int> MonthlyLeaves { get; set; } = new();

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

        var currentYear = DateTime.Now.Year;
        MonthlyJoins = employees
            .Where(e => e.JoinDate.Year == currentYear)
            .GroupBy(e => e.JoinDate.ToString("MMMM"))
            .ToDictionary(g => g.Key, g => g.Count());

        MonthlyLeaves = employees
            .Where(e => e.LeaveDate?.Year == currentYear)
            .GroupBy(e => e.LeaveDate?.ToString("MMMM"))
            .ToDictionary(g => g.Key!, g => g.Count());

        await base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && !_isChartLoaded)
        {
            await LoadModule();
            await LoadDepartmentChart();
            await LoadEmployeeFlowChart();
            _isChartLoaded = true;
        }
    }

    private async Task LoadModule()
    {
        await JsRuntime.InvokeVoidAsync("import", "./Pages/AdminView/AdminDashboard.razor.js");
    }

    private async Task LoadDepartmentChart()
    {
        var departmentLabels = EmployeesByDepartment.Keys.ToArray();
        var departmentCounts = EmployeesByDepartment.Values.ToArray();

        await JsRuntime.InvokeVoidAsync("renderDepartmentChart", departmentLabels, departmentCounts);
    }

    private async Task LoadEmployeeFlowChart()
    {
        var allEmployees = await EmployeeService.GetEmployeesAsync();
        var currentYear = DateTime.Now.Year;
        var lastYear = currentYear - 1;

        var monthlyJoins = new Dictionary<string, Dictionary<int, int>>();
        var monthlyLeaves = new Dictionary<string, Dictionary<int, int>>();

        var months = new[]
        {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        foreach (var month in months)
        {
            monthlyJoins[month] = new Dictionary<int, int> { { lastYear, 0 }, { currentYear, 0 } };
            monthlyLeaves[month] = new Dictionary<int, int> { { lastYear, 0 }, { currentYear, 0 } };
        }

        foreach (var employee in allEmployees)
        {
            var joinMonth = employee.JoinDate.ToString("MMMM");
            var joinYear = employee.JoinDate.Year;

            if (joinYear == currentYear || joinYear == lastYear) monthlyJoins[joinMonth][joinYear]++;

            if (employee.LeaveDate.HasValue)
            {
                var leaveMonth = employee.LeaveDate.Value.ToString("MMMM");
                var leaveYear = employee.LeaveDate.Value.Year;

                if (leaveYear == currentYear || leaveYear == lastYear) monthlyLeaves[leaveMonth][leaveYear]++;
            }
        }

        var lastYearJoinData = months.Select(m => monthlyJoins[m][lastYear]).ToArray();
        var currentYearJoinData = months.Select(m => monthlyJoins[m][currentYear]).ToArray();
        var lastYearLeaveData = months.Select(m => monthlyLeaves[m][lastYear]).ToArray();
        var currentYearLeaveData = months.Select(m => monthlyLeaves[m][currentYear]).ToArray();

        await JsRuntime.InvokeVoidAsync("destroyChart", "employeeFlowChart");
        await JsRuntime.InvokeVoidAsync("renderEmployeeFlowChart", months,
            currentYearJoinData, currentYearLeaveData, lastYearJoinData, lastYearLeaveData,
            lastYear, currentYear);
    }
}