using HRApp.Models;

namespace HRApp.Services.Calendar
{
    public interface ICalendarEventService
    {
        Task<List<CalendarEvent>> GetAllEventsAsync();
        Task<List<CalendarEvent>> GetUserEventsAsync(int userId);
        Task<List<CalendarEvent>> GetTimeOffEventsAsync(int userId, bool isAdmin);
        Task<List<CalendarEvent>> GetPendingEventsAsync();
        Task ApproveEventAsync(CalendarEvent calendarEvent, string approvedBy);
        Task SaveEventAsync(CalendarEvent calendarEvent);
    }
}