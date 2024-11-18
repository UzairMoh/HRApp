using HRApp.Models;
using HRApp.Repositories.Calendar;

namespace HRApp.Services.Calendar
{
    public class CalendarEventService(ICalendarEventRepository calendarEventRepository) : ICalendarEventService
    {
        public async Task<List<CalendarEvent>> GetAllEventsAsync()
        {
            return await calendarEventRepository.GetAllEventsAsync();
        }

        public async Task<List<CalendarEvent>> GetUserEventsAsync(int userId)
        {
            return await calendarEventRepository.GetUserEventsAsync(userId);
        }

        public async Task<List<CalendarEvent>> GetTimeOffEventsAsync(int userId, bool isAdmin)
        {
            return await calendarEventRepository.GetTimeOffEventsAsync(userId, isAdmin);
        }

        public async Task<List<CalendarEvent>> GetPendingEventsAsync()
        {
            return await calendarEventRepository.GetPendingEventsAsync();
        }

        public async Task ApproveEventAsync(CalendarEvent calendarEvent, string approvedBy)
        {
            calendarEvent.IsApproved = true;
            calendarEvent.ApprovedAt = DateTime.UtcNow;
            calendarEvent.ApprovedBy = approvedBy;
            await calendarEventRepository.UpdateEventAsync(calendarEvent);
        }

        public async Task SaveEventAsync(CalendarEvent calendarEvent)
        {
            if (calendarEvent.Id == 0)
            {
                await calendarEventRepository.AddEventAsync(calendarEvent);
            }
            else
            {
                await calendarEventRepository.UpdateEventAsync(calendarEvent);
            }
        }
    }
}