using HRApp.Models;
using HRApp.Models.Enums;

namespace HRApp.Services.Leave;

public interface ILeaveManagementService
{
    Task<IEnumerable<TimeOffRequest>> GetUserRequestsAsync(int employeeId);
    Task<TimeOffRequest> SubmitRequestAsync(TimeOffRequest request);
    Task<bool> CancelRequestAsync(int requestId, int employeeId);
    Task<IEnumerable<TimeOffRequest>> GetPendingRequestsAsync();
    Task<IEnumerable<TimeOffRequest>> GetAllRequestsAsync();
    Task<TimeOffRequest> UpdateRequestStatusAsync(int requestId, RequestStatus status, string reviewedBy, string? comments = null);
    Task<TimeOffRequest?> GetRequestByIdAsync(int requestId);
    Task<IEnumerable<TimeOffRequest>> GetApprovedRequestsForPeriodAsync(DateTime start, DateTime end);
    Task<IEnumerable<TimeOffRequest>> GetByStatusAsync(RequestStatus status);
}