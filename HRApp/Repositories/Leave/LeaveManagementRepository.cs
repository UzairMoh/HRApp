using HRApp.Data;
using HRApp.Models;
using HRApp.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Repositories.Leave;

public class LeaveManagementRepository : ILeaveManagementRepository
{
   private readonly DataContext _context;

   public LeaveManagementRepository(DataContext context)
   {
       _context = context;
   }

   public async Task<TimeOffRequest?> GetByIdAsync(int requestId)
   {
       return await _context.TimeOffRequests
           .Include(t => t.Employee)
           .FirstOrDefaultAsync(t => t.Id == requestId);
   }

   public async Task<TimeOffRequest> CreateAsync(TimeOffRequest request)
   {
       _context.TimeOffRequests.Add(request);
       await _context.SaveChangesAsync();
       return request;
   }

   public async Task<TimeOffRequest> UpdateAsync(TimeOffRequest request)
   {
       _context.TimeOffRequests.Update(request);
       await _context.SaveChangesAsync();
       return request;
   }

   public async Task DeleteAsync(int requestId)
   {
       var request = await _context.TimeOffRequests.FindAsync(requestId);
       if (request != null)
       {
           _context.TimeOffRequests.Remove(request);
           await _context.SaveChangesAsync();
       }
   }

   public async Task<IEnumerable<TimeOffRequest>> GetAllAsync()
   {
       return await _context.TimeOffRequests
           .Include(t => t.Employee)
           .ToListAsync();
   }

   public async Task<IEnumerable<TimeOffRequest>> GetByEmployeeIdAsync(int employeeId)
   {
       return await _context.TimeOffRequests
           .Include(t => t.Employee)
           .Where(t => t.EmployeeId == employeeId)
           .OrderByDescending(t => t.CreatedAt)
           .ToListAsync();
   }

   public async Task<IEnumerable<TimeOffRequest>> GetByStatusAsync(RequestStatus status)
   {
       return await _context.TimeOffRequests
           .Include(t => t.Employee)
           .Where(t => t.Status == status)
           .OrderByDescending(t => t.CreatedAt)
           .ToListAsync();
   }

   public async Task<IEnumerable<TimeOffRequest>> GetApprovedRequestsInPeriodAsync(DateTime start, DateTime end)
   {
       return await _context.TimeOffRequests
           .Include(t => t.Employee)
           .Where(t => t.Status == RequestStatus.Approved 
                      && ((t.StartDate >= start && t.StartDate <= end) 
                          || (t.EndDate >= start && t.EndDate <= end)))
           .OrderBy(t => t.StartDate)
           .ToListAsync();
   }

   public async Task<bool> HasOverlappingRequestAsync(int employeeId, DateTime start, DateTime end)
   {
       return await _context.TimeOffRequests
           .AnyAsync(t => t.EmployeeId == employeeId 
                         && t.Status != RequestStatus.Rejected
                         && ((t.StartDate >= start && t.StartDate <= end) 
                             || (t.EndDate >= start && t.EndDate <= end)));
   }

   public async Task<IEnumerable<TimeOffRequest>> GetRequestsByDateRangeAsync(DateTime start, DateTime end)
   {
       return await _context.TimeOffRequests
           .Include(t => t.Employee)
           .Where(t => (t.StartDate >= start && t.StartDate <= end) 
                      || (t.EndDate >= start && t.EndDate <= end))
           .OrderBy(t => t.StartDate)
           .ToListAsync();
   }
}