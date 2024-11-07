using HRApp.Models;

namespace HRApp.Repositories.Calendar
{
    public interface ICalendarEventRepository
    {
        Task<List<CalendarEvent>> GetAllEventsAsync();
        Task<List<CalendarEvent>> GetUserEventsAsync(int userId);
        Task<List<CalendarEvent>> GetTimeOffEventsAsync(int userId, bool isAdmin);
        Task AddEventAsync(CalendarEvent calendarEvent);
        Task UpdateEventAsync(CalendarEvent calendarEvent);
    }
}