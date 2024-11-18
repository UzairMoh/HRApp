using HRApp.Models;
using HRApp.Services.Calendar;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Radzen.Blazor;

namespace HRApp.Pages.CalendarView;

public partial class Calendar
{
    [Inject] private DialogService? DialogService { get; set; }
    [Inject] private ICalendarEventService? CalendarEventService { get; set; }
    [Inject] private AuthenticationStateProvider? AuthenticationStateProvider { get; set; }

    private RadzenScheduler<CalendarEvent>? scheduler;
    private List<CalendarEvent> events = new();
    private int currentUserId;

    protected override async Task OnInitializedAsync()
    {
        if (AuthenticationStateProvider != null)
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            
            var employeeIdClaim = user.FindFirst("employee_id")?.Value;
            if (!string.IsNullOrEmpty(employeeIdClaim) && int.TryParse(employeeIdClaim, out int employeeId))
            {
                currentUserId = employeeId;
                await LoadEvents();
            }
        }
    }

    private async Task LoadEvents()
    {
        if (CalendarEventService == null) return;

        var authState = await AuthenticationStateProvider!.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        try
        {
            if (isAdmin)
            {
                events = await CalendarEventService.GetAllEventsAsync();
            }
            else
            {
                events = await CalendarEventService.GetUserEventsAsync(currentUserId);
            }

            var timeOffEvents = await CalendarEventService.GetTimeOffEventsAsync(currentUserId, isAdmin);
            events.AddRange(timeOffEvents);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading events: {ex.Message}");
            events = new List<CalendarEvent>();
        }
    }

    private async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<CalendarEvent> args)
    {
        var copy = new CalendarEvent
        {
            Id = args.Data.Id,
            Start = args.Data.Start,
            End = args.Data.End,
            Title = args.Data.Title,
            Description = args.Data.Description,
            IsCompanyWide = args.Data.IsCompanyWide,
            EmployeeId = args.Data.EmployeeId
        };

        var data = await DialogService!.OpenAsync<EditCalendarEvent>("Edit Event", 
            new Dictionary<string, object> { { "CalendarEvent", copy } });

        if (data != null)
        {
            args.Data.Start = data.Start;
            args.Data.End = data.End;
            args.Data.Title = data.Title;
            args.Data.Description = data.Description;
            args.Data.IsCompanyWide = data.IsCompanyWide;

            await CalendarEventService!.SaveEventAsync(args.Data);
            await scheduler!.Reload();
        }
    }

    private async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
    {
        var newEvent = new CalendarEvent
        {
            Start = args.Start,
            End = args.End,
            EmployeeId = currentUserId
        };

        var data = await DialogService!.OpenAsync<EditCalendarEvent>("New Event", 
            new Dictionary<string, object> { { "CalendarEvent", newEvent } });

        if (data != null)
        {
            await CalendarEventService!.SaveEventAsync(data);
            await scheduler!.Reload();
        }
    }
}