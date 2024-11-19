using HRApp.Models;
using HRApp.Models.Enums;
using HRApp.Services.Leave;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace HRApp.Pages.AdminView;

public partial class TimeOffAdmin
{
    [Inject] private ILeaveManagementService LeaveManagementService { get; set; } = default!;
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private NotificationService NotificationService { get; set; } = default!;

    private List<TimeOffRequest> requests = new();
    private RequestStatus? selectedStatus;

    protected override async Task OnInitializedAsync()
    {
        await LoadRequests();
    }

    private async Task LoadRequests()
    {
        if (selectedStatus.HasValue)
        {
            var filteredRequests = await LeaveManagementService.GetByStatusAsync(selectedStatus.Value);
            requests = filteredRequests.ToList();
        }
        else
        {
            var allRequests = await LeaveManagementService.GetAllRequestsAsync();
            requests = allRequests.ToList();
        }
    }

    private async Task ApproveRequest(TimeOffRequest request)
    {
        var result = await DialogService.Confirm(
            $"Are you sure you want to approve {request.Employee?.FirstName}'s time off request?",
            "Confirm Approval",
            new ConfirmOptions() { OkButtonText = "Yes", CancelButtonText = "No" });

        if (result == true)
        {
            await LeaveManagementService.UpdateRequestStatusAsync(
                request.Id,
                RequestStatus.Approved,
                "Admin", // You might want to get the actual admin name
                "Request approved");

            await LoadRequests();
            NotificationService.Notify(NotificationSeverity.Success, "Request Approved");
        }
    }

    private async Task RejectRequest(TimeOffRequest request)
    {
        await LeaveManagementService.UpdateRequestStatusAsync(
            request.Id,
            RequestStatus.Rejected,
            "Admin");

        await LoadRequests();
        NotificationService.Notify(NotificationSeverity.Info, "Request Rejected");
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