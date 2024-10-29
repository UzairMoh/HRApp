using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using HRApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRApp.Models;

namespace HRApp.Pages
{
    public partial class Home : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; } = null!;

        [Inject]
        public IJSRuntime JSRuntime { get; set; } = null!;
        
        [Inject]
        public TokenProvider TokenProvider { get; set; } = null!;

        private int TotalEmployees { get; set; }
        private int TotalMaleEmployees { get; set; }
        private int TotalFemaleEmployees { get; set; }
        private Dictionary<string, int> EmployeesByDepartment { get; set; } = new Dictionary<string, int>();

        private bool _isChartLoaded;
        
        private string IdToken = "";

        protected override async Task OnInitializedAsync()
        {
            var employees = await EmployeeService.GetEmployeesAsync();

            TotalEmployees = employees.Count;
            TotalMaleEmployees = employees.Count(e => e.Gender == "Male");
            TotalFemaleEmployees = employees.Count(e => e.Gender == "Female");
            EmployeesByDepartment = employees
                .GroupBy(e => e.Department)
                .ToDictionary(g => g.Key, g => g.Count());
            
            IdToken = TokenProvider.IdToken;

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
            await JSRuntime.InvokeVoidAsync("import", "./Pages/Home.razor.js");
        }

        private async Task LoadDepartmentChart()
        {
            var departmentLabels = EmployeesByDepartment.Keys.ToArray();
            var departmentCounts = EmployeesByDepartment.Values.ToArray();

            await JSRuntime.InvokeVoidAsync("renderDepartmentChart", departmentLabels, departmentCounts);
        }
    }
}