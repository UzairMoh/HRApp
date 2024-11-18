using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using HRApp.Models;
using HRApp.Services.Employee;

namespace HRApp.Pages.UserView
{
    public partial class Profile
    {
        [Inject]
        private IEmployeeService? EmployeeService { get; set; }

        [CascadingParameter]
        public Task<AuthenticationState>? AuthenticationStateTask { get; set; }

        private Employees? UserProfile { get; set; }
        
        private string _picture = "";

        protected override async Task OnInitializedAsync()
        {
            var state = await AuthenticationStateTask!;
            var email = state.User.Claims
                .Where(c => c.Type.Equals(System.Security.Claims.ClaimTypes.Email))
                .Select(c => c.Value)
                .FirstOrDefault();

            if (!string.IsNullOrEmpty(email))
            {
                UserProfile = (await EmployeeService!.GetEmployeesAsync())
                    .FirstOrDefault(e => e.Email == email);
            }
            
            _picture = state.User.Claims
                .Where(c => c.Type.Equals("picture"))
                .Select(c => c.Value)
                .FirstOrDefault() ?? string.Empty;


            await base.OnInitializedAsync();
        }
    }
}