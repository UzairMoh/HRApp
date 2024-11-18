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
            // Initialize empty list
            events = new List<CalendarEvent>();

            if (isAdmin)
            {
                // Get all events - no need to get pending events separately
                // as they're already included in GetAllEventsAsync
                events = await CalendarEventService.GetAllEventsAsync();
            }
            else
            {
                events = await CalendarEventService.GetUserEventsAsync(currentUserId);
            }

            // Add time off events
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
        var authState = await AuthenticationStateProvider!.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        if (!isAdmin && args.Data.EmployeeId != currentUserId)
        {
            return;
        }

        var copy = new CalendarEvent
        {
            Id = args.Data.Id,
            Start = args.Data.Start,
            End = args.Data.End,
            Title = args.Data.Title,
            Description = args.Data.Description,
            IsCompanyWide = args.Data.IsCompanyWide,
            EmployeeId = args.Data.EmployeeId,
            IsApproved = args.Data.IsApproved,
            ApprovedAt = args.Data.ApprovedAt,
            ApprovedBy = args.Data.ApprovedBy
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
            args.Data.IsApproved = data.IsApproved;
            args.Data.ApprovedAt = data.ApprovedAt;
            args.Data.ApprovedBy = data.ApprovedBy;

            await CalendarEventService!.SaveEventAsync(args.Data);
            await scheduler!.Reload();
        }
    }

    private async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
    {
        if (AuthenticationStateProvider == null) return;

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        // Create new event with properly set EmployeeId
        var newEvent = new CalendarEvent
        {
            Start = args.Start,
            End = args.End,
            EmployeeId = currentUserId,  // Make sure this is set
            IsApproved = isAdmin, // Auto-approve if admin
            IsCompanyWide = false
        };

        if (isAdmin)
        {
            newEvent.ApprovedBy = authState.User.Identity?.Name ?? "Admin";
            newEvent.ApprovedAt = DateTime.UtcNow;
        }

        var data = await DialogService!.OpenAsync<EditCalendarEvent>("New Event", 
            new Dictionary<string, object> { { "CalendarEvent", newEvent } });

        if (data != null)
        {
            // Ensure EmployeeId is maintained
            data.EmployeeId = currentUserId;
        
            await CalendarEventService!.SaveEventAsync(data);
            await scheduler!.Reload();
        }
    }
    
    private void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<CalendarEvent> args)
    {
        if (args.Data.Title?.StartsWith("Time Off -") == true)
        {
            // Soft coral/salmon color
            args.Attributes["style"] = "background: #FF7F7F; color: white;";
        }
        else if (args.Data.IsCompanyWide)
        {
            // Mint/sage green
            args.Attributes["style"] = "background: #7FB77E; color: white;";
        }
        else if (!args.Data.IsApproved)
        {
            // Muted gold
            args.Attributes["style"] = "background: #EEBD00; color: white;";
        }
        else if (args.Data.EmployeeId == currentUserId)
        {
            // Soft purple/lavender
            args.Attributes["style"] = "background: #A084DC; color: white;";
        }
        else
        {
            // Ocean blue
            args.Attributes["style"] = "background: #6096B4; color: white;";
        }
    }
}