using HRApp.Models;
using HRApp.Services.Calendar;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

namespace HRApp.Pages.EventView;

public partial class EditEvent
{
    [Parameter]
    public CalendarEvent CalendarEvent { get; set; } = new();

    [Inject]
    private DialogService DialogService { get; set; } = default!;

    [Inject]
    private ICalendarEventService CalendarEventService { get; set; } = default!;

    [Inject]
    private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    private async Task ApproveEvent()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var adminUser = authState.User.Identity?.Name ?? "Admin";
        
        CalendarEvent.IsApproved = true;
        CalendarEvent.ApprovedAt = DateTime.UtcNow;
        CalendarEvent.ApprovedBy = adminUser;
        
        DialogService.Close(CalendarEvent);
    }

    private async Task SaveEvent()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        if (!isAdmin)
        {
            CalendarEvent.IsApproved = false;
            CalendarEvent.ApprovedAt = null;
            CalendarEvent.ApprovedBy = null;
            
            if (CalendarEvent.EmployeeId == null || CalendarEvent.EmployeeId == 0)
            {
                await SetEmployeeIdFromClaims(authState);
            }
        }

        DialogService.Close(CalendarEvent);
    }

    private async Task SetEmployeeIdFromClaims(AuthenticationState authState)
    {
        var employeeIdClaim = authState.User.FindFirst("employee_id")?.Value;
        if (!string.IsNullOrEmpty(employeeIdClaim) && int.TryParse(employeeIdClaim, out int employeeId))
        {
            CalendarEvent.EmployeeId = employeeId;
        }
    }
}