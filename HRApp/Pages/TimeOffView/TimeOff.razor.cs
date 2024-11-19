using HRApp.Models;
using HRApp.Models.Enums;
using HRApp.Services.Leave;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HRApp.Pages.TimeOffView;

public partial class TimeOff
{
    [Inject] private ILeaveManagementService LeaveManagementService { get; set; } = default!;
    [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;
    
    private TimeOffRequest newRequest = new();
    private List<TimeOffRequest> requests = new();
    private int _currentUserId;

    protected override async Task OnInitializedAsync()
    {
        if (AuthenticationStateProvider != null)
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            
            var employeeIdClaim = user.FindFirst("employee_id")?.Value;
            if (!string.IsNullOrEmpty(employeeIdClaim) && int.TryParse(employeeIdClaim, out int employeeId))
            {
                _currentUserId = employeeId;
                await LoadRequests();
            }
        }
    }
    
    private async Task LoadRequests()
    {
        var result = await LeaveManagementService.GetUserRequestsAsync(_currentUserId);
        requests = result.ToList();
    }
    
    private async Task SubmitRequest()
    {
        newRequest.EmployeeId = _currentUserId;
        await LeaveManagementService.SubmitRequestAsync(newRequest);
        await LoadRequests();
        newRequest = new TimeOffRequest();
    }
    
    private static string GetStatusClass(RequestStatus status) => status switch
    {
        RequestStatus.Pending => "status-pending",
        RequestStatus.Approved => "status-approved",
        RequestStatus.Rejected => "status-rejected",
        RequestStatus.Cancelled => "status-cancelled",
        _ => string.Empty
    };
}