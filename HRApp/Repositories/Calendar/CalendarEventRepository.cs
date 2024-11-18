using HRApp.Data;
using HRApp.Models;
using HRApp.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Repositories.Calendar
{
    public class CalendarEventRepository(DataContext context) : ICalendarEventRepository
    {
        public async Task<List<CalendarEvent>> GetAllEventsAsync()
        {
            return await context.CalendarEvents.Include(e => e.Employee).ToListAsync();
        }

        public async Task<List<CalendarEvent>> GetUserEventsAsync(int userId)
        {
            return await context.CalendarEvents
                .Include(e => e.Employee)
                .Where(e => e.IsCompanyWide || e.EmployeeId == userId)
                .ToListAsync();
        }
        
        public async Task<List<CalendarEvent>> GetPendingEventsAsync()
        {
            return await context.CalendarEvents
                .Include(e => e.Employee)
                .Where(e => !e.IsApproved && !e.IsCompanyWide)
                .ToListAsync();
        }

        public async Task<List<CalendarEvent>> GetTimeOffEventsAsync(int userId, bool isAdmin)
        {
            return await context.TimeOffRequests
                .Include(t => t.Employee)
                .Where(t => t.Status == RequestStatus.Approved && (isAdmin || t.EmployeeId == userId))
                .Select(t => new CalendarEvent
                {
                    Title = $"Time Off - {t.Employee!.FirstName} {t.Employee.LastName} ({t.Type})",
                    Description = t.Description,
                    Start = t.StartDate,
                    End = t.EndDate,
                    EmployeeId = t.EmployeeId,
                    IsCompanyWide = false
                })
                .ToListAsync();
        }

        public async Task AddEventAsync(CalendarEvent calendarEvent)
        {
            context.CalendarEvents.Add(calendarEvent);
            await context.SaveChangesAsync();
        }

        public async Task UpdateEventAsync(CalendarEvent calendarEvent)
        {
            context.CalendarEvents.Update(calendarEvent);
            await context.SaveChangesAsync();
        }
    }
}