using HRApp.Models;
using HRApp.Models.Enums;
using HRApp.Services.Leave;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;

namespace HRApp.Pages.AdminView;

public partial class TimeOffAdmin
{
    [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;
    [Inject] private ILeaveManagementService LeaveManagementService { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private List<TimeOffRequest> _requests = new();
    private RequestStatus? _selectedStatus;

    protected override async Task OnInitializedAsync()
    {
        await LoadRequests();
    }

    private async Task LoadRequests()
    {
        if (_selectedStatus.HasValue)
        {
            var filteredRequests = await LeaveManagementService.GetByStatusAsync(_selectedStatus.Value);
            _requests = filteredRequests.ToList();
        }
        else
        {
            var allRequests = await LeaveManagementService.GetAllRequestsAsync();
            _requests = allRequests.ToList();
        }
    }

    private async Task ApproveRequest(TimeOffRequest request)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        if (!isAdmin) return;

        var result = await DialogService.Confirm(
            $"Are you sure you want to approve {request.Employee?.FirstName}'s time off request?",
            "Confirm Approval",
            new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });

        if (result == true)
        {
            SetAdminApproval(request, authState.User.Identity?.Name);
            await LeaveManagementService.UpdateRequestStatusAsync(request.Id, request.Status, request.ReviewedBy);
            await LoadRequests();
            NotificationService.Notify(NotificationSeverity.Success, "Request Approved");
        }
    }

    private static void SetAdminApproval(TimeOffRequest request, string? adminName)
    {
        request.Status = RequestStatus.Approved;
        request.ReviewedBy = adminName ?? "Admin";
        request.ReviewedAt = DateTime.UtcNow;
    }

    private async Task RejectRequest(TimeOffRequest request)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        if (!isAdmin) return;

        var result = await DialogService.Confirm(
            $"Are you sure you want to reject {request.Employee?.FirstName}'s time off request?",
            "Confirm Rejection",
            new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });

        if (result == true)
        {
            SetAdminRejection(request, authState.User.Identity?.Name);
            await LeaveManagementService.UpdateRequestStatusAsync(request.Id, request.Status, request.ReviewedBy);
            await LoadRequests();
            NotificationService.Notify(NotificationSeverity.Info, "Request Rejected");
        }
    }

    private static void SetAdminRejection(TimeOffRequest request, string? adminName)
    {
        request.Status = RequestStatus.Rejected;
        request.ReviewedBy = adminName ?? "Admin";
        request.ReviewedAt = DateTime.UtcNow;
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