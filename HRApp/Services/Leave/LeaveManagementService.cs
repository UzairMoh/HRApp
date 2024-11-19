using HRApp.Models;
using HRApp.Models.Enums;
using HRApp.Repositories.Leave;

namespace HRApp.Services.Leave;

public class LeaveManagementService : ILeaveManagementService
{
   private readonly ILeaveManagementRepository _leaveManagementRepository;

   public LeaveManagementService(ILeaveManagementRepository leaveManagementRepository)
   {
       _leaveManagementRepository = leaveManagementRepository;
   }

   public async Task<IEnumerable<TimeOffRequest>> GetUserRequestsAsync(int employeeId)
   {
       return await _leaveManagementRepository.GetByEmployeeIdAsync(employeeId);
   }

   Task<TimeOffRequest> ILeaveManagementService.SubmitRequestAsync(TimeOffRequest request)
   {
       return SubmitRequestAsync(request);
   }

   Task<bool> ILeaveManagementService.CancelRequestAsync(int requestId, int employeeId)
   {
       return CancelRequestAsync(requestId, employeeId);
   }

   Task<IEnumerable<TimeOffRequest>> ILeaveManagementService.GetPendingRequestsAsync()
   {
       return GetPendingRequestsAsync();
   }

   Task<IEnumerable<TimeOffRequest>> ILeaveManagementService.GetAllRequestsAsync()
   {
       return GetAllRequestsAsync();
   }

   Task<TimeOffRequest> ILeaveManagementService.UpdateRequestStatusAsync(int requestId, RequestStatus status, string reviewedBy, string? comments)
   {
       return UpdateRequestStatusAsync(requestId, status, reviewedBy, comments);
   }

   Task<TimeOffRequest?> ILeaveManagementService.GetRequestByIdAsync(int requestId)
   {
       return GetRequestByIdAsync(requestId);
   }

   Task<IEnumerable<TimeOffRequest>> ILeaveManagementService.GetApprovedRequestsForPeriodAsync(DateTime start, DateTime end)
   {
       return GetApprovedRequestsForPeriodAsync(start, end);
   }

   public async Task<TimeOffRequest> SubmitRequestAsync(TimeOffRequest request)
   {
       request.Status = RequestStatus.Pending;
       request.CreatedAt = DateTime.UtcNow;
       return await _leaveManagementRepository.CreateAsync(request);
   }

   public async Task<bool> CancelRequestAsync(int requestId, int employeeId)
   {
       var request = await _leaveManagementRepository.GetByIdAsync(requestId);
       
       if (request == null || request.EmployeeId != employeeId)
           return false;

       if (request.Status != RequestStatus.Pending && request.Status != RequestStatus.Approved)
           return false;

       request.Status = RequestStatus.Cancelled;
       await _leaveManagementRepository.UpdateAsync(request);
       return true;
   }

   public async Task<IEnumerable<TimeOffRequest>> GetPendingRequestsAsync()
   {
       return await _leaveManagementRepository.GetByStatusAsync(RequestStatus.Pending);
   }

   public async Task<IEnumerable<TimeOffRequest>> GetAllRequestsAsync()
   {
       return await _leaveManagementRepository.GetAllAsync();
   }

   public async Task<TimeOffRequest> UpdateRequestStatusAsync(int requestId, RequestStatus status, string reviewedBy, string? comments = null)
   {
       var request = await _leaveManagementRepository.GetByIdAsync(requestId) 
           ?? throw new InvalidOperationException("Request not found");

       request.Status = status;
       request.ReviewedBy = reviewedBy;
       request.ReviewedAt = DateTime.UtcNow;
       request.AdminComments = comments;

       return await _leaveManagementRepository.UpdateAsync(request);
   }

   public async Task<TimeOffRequest?> GetRequestByIdAsync(int requestId)
   {
       return await _leaveManagementRepository.GetByIdAsync(requestId);
   }

   public async Task<IEnumerable<TimeOffRequest>> GetApprovedRequestsForPeriodAsync(DateTime start, DateTime end)
   {
       return await _leaveManagementRepository.GetApprovedRequestsInPeriodAsync(start, end);
   }
}