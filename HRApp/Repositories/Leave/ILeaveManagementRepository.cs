using HRApp.Models;
using HRApp.Models.Enums;

namespace HRApp.Repositories.Leave;

public interface ILeaveManagementRepository
{
    Task<TimeOffRequest?> GetByIdAsync(int requestId);
    Task<TimeOffRequest> CreateAsync(TimeOffRequest request);
    Task<TimeOffRequest> UpdateAsync(TimeOffRequest request);
    Task DeleteAsync(int requestId);
    Task<IEnumerable<TimeOffRequest>> GetAllAsync();
    Task<IEnumerable<TimeOffRequest>> GetByEmployeeIdAsync(int employeeId);
    Task<IEnumerable<TimeOffRequest>> GetByStatusAsync(RequestStatus status);
    Task<IEnumerable<TimeOffRequest>> GetApprovedRequestsInPeriodAsync(DateTime start, DateTime end);
    Task<bool> HasOverlappingRequestAsync(int employeeId, DateTime start, DateTime end);
    Task<IEnumerable<TimeOffRequest>> GetRequestsByDateRangeAsync(DateTime start, DateTime end);
}