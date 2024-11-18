using HRApp.Models;
using HRApp.Services.Employee;
using HRApp.Services.Calendar;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HRApp.Pages.UserView;

public partial class Dashboard
{
    [Inject] 
    private IEmployeeService? EmployeeService { get; set; }
    
    [Inject] 
    private ICalendarEventService? CalendarEventService { get; set; }
    
    [Inject] 
    private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    private int currentUserId;
    private Employees? employee;
    private List<CalendarEvent> timeOffRequests = new();

    protected override async Task OnInitializedAsync()
    {
        if (AuthenticationStateProvider != null)
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            var employeeIdClaim = user.FindFirst("employee_id")?.Value;
            if (!string.IsNullOrEmpty(employeeIdClaim) && int.TryParse(employeeIdClaim, out int employeeId))
            {
                currentUserId = employeeId;
                await LoadEmployeeData();
                await LoadTimeOffRequests();
            }
        }
    }

    private async Task LoadEmployeeData()
    {
        if (EmployeeService != null)
        {
            employee = await EmployeeService.GetEmployeeAsync(currentUserId);
        }
    }

    private async Task LoadTimeOffRequests()
    {
        if (CalendarEventService != null)
        {
            timeOffRequests = await CalendarEventService.GetTimeOffEventsAsync(currentUserId, false);
        }
    }
}