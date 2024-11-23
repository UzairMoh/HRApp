using HRApp.Models;
using HRApp.Services.Calendar;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Radzen;
using Radzen.Blazor;

namespace HRApp.Pages.EventView;

public partial class Events
{
    [Inject] private DialogService DialogService { get; set; } = default!;
    [Inject] private ICalendarEventService CalendarEventService { get; set; } = default!;
    [Inject] private AuthenticationStateProvider AuthenticationStateProvider { get; set; } = default!;

    private RadzenScheduler<CalendarEvent>? _scheduler;
    private List<CalendarEvent> _events = new();
    private int _currentUserId;

    private static class EventColors
    {
        public const string TimeOff = "#FF7F7F";
        public const string CompanyWide = "#7FB77E";
        public const string Pending = "#EEBD00";
        public const string UserEvent = "#A084DC";
        public const string AdminEvent = "#6096B4";
        public const string TextColor = "white";
    }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        _currentUserId = await GetEmployeeIdFromClaims(authState.User);
        
        if (_currentUserId > 0)
        {
            await LoadEvents();
        }
    }
    
    private async Task RefreshCalendar()
    {
        await LoadEvents();
    
        if (_scheduler != null)
        {
            await _scheduler.Reload();
        }
    
        StateHasChanged();
    }

    private Task<int> GetEmployeeIdFromClaims(System.Security.Claims.ClaimsPrincipal user)
    {
        var employeeIdClaim = user.FindFirst("employee_id")?.Value;
        return Task.FromResult(!string.IsNullOrEmpty(employeeIdClaim) && int.TryParse(employeeIdClaim, out int employeeId) 
            ? employeeId 
            : 0);
    }

    private async Task LoadEvents()
    {
        try
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var isAdmin = authState.User.IsInRole("Admin");

            _events = await LoadUserSpecificEvents(isAdmin);
            var timeOffEvents = await CalendarEventService.GetTimeOffEventsAsync(_currentUserId, isAdmin);
            _events.AddRange(timeOffEvents);
        }
        catch (Exception ex)
        {
            HandleLoadError(ex);
        }
    }

    private async Task<List<CalendarEvent>> LoadUserSpecificEvents(bool isAdmin)
    {
        return isAdmin 
            ? await CalendarEventService.GetAllEventsAsync() 
            : await CalendarEventService.GetUserEventsAsync(_currentUserId);
    }

    private async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<CalendarEvent> args)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        if (!isAdmin && args.Data.EmployeeId == _currentUserId && !args.Data.IsApproved)
        {
            await DialogService.Alert("This event is pending approval and cannot be edited.", "Pending Approval");
            return;
        }

        if (!await CanEditEvent(args.Data))
            return;

        var eventCopy = CreateEventCopy(args.Data);
        var updatedEvent = await OpenEventDialog("Edit Event", eventCopy);

        if (updatedEvent != null)
        {
            await UpdateExistingEvent(args.Data, updatedEvent);
            await RefreshCalendar();
        }
    }

    private async Task<bool> CanEditEvent(CalendarEvent calendarEvent)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        if (isAdmin)
            return true;

        if (!calendarEvent.IsApproved)
            return false;

        return calendarEvent.EmployeeId == _currentUserId && calendarEvent.IsApproved;
    }

    private static CalendarEvent CreateEventCopy(CalendarEvent original)
    {
        return new CalendarEvent
        {
            Id = original.Id,
            Start = original.Start,
            End = original.End,
            Title = original.Title,
            Description = original.Description,
            IsCompanyWide = original.IsCompanyWide,
            EmployeeId = original.EmployeeId,
            IsApproved = original.IsApproved,
            ApprovedAt = original.ApprovedAt,
            ApprovedBy = original.ApprovedBy
        };
    }

    private async Task UpdateExistingEvent(CalendarEvent original, CalendarEvent updated)
    {
        UpdateEventProperties(original, updated);
        await CalendarEventService.SaveEventAsync(original);
        await _scheduler!.Reload();
    }

    private static void UpdateEventProperties(CalendarEvent target, CalendarEvent source)
    {
        target.Start = source.Start;
        target.End = source.End;
        target.Title = source.Title;
        target.Description = source.Description;
        target.IsCompanyWide = source.IsCompanyWide;
        target.IsApproved = source.IsApproved;
        target.ApprovedAt = source.ApprovedAt;
        target.ApprovedBy = source.ApprovedBy;
    }

    private async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
    {
        var newEvent = await CreateNewEvent(args.Start, args.End);
        var savedEvent = await OpenEventDialog("New Event", newEvent);

        if (savedEvent != null)
        {
            savedEvent.EmployeeId = _currentUserId;
            await CalendarEventService.SaveEventAsync(savedEvent);
            await _scheduler!.Reload();
            await RefreshCalendar();
        }
    }

    private async Task<CalendarEvent> CreateNewEvent(DateTime start, DateTime end)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var isAdmin = authState.User.IsInRole("Admin");

        var newEvent = new CalendarEvent
        {
            Start = start,
            End = end,
            EmployeeId = _currentUserId,
            IsApproved = isAdmin,
            IsCompanyWide = false
        };

        if (isAdmin)
        {
            SetAdminApproval(newEvent, authState.User.Identity?.Name);
        }

        return newEvent;
    }

    private static void SetAdminApproval(CalendarEvent calendarEvent, string? adminName)
    {
        calendarEvent.ApprovedBy = adminName ?? "Admin";
        calendarEvent.ApprovedAt = DateTime.UtcNow;
    }

    private async Task<CalendarEvent?> OpenEventDialog(string title, CalendarEvent calendarEvent)
    {
        return await DialogService.OpenAsync<EditEvent>(title, 
            new Dictionary<string, object> { { "CalendarEvent", calendarEvent } });
    }

    private void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<CalendarEvent> args)
    {
        var style = GetEventStyle(args.Data);
        args.Attributes["style"] = style;
    }

    private string GetEventStyle(CalendarEvent calendarEvent)
    {
        if (calendarEvent.Title?.StartsWith("Time Off -") == true)
            return $"background: {EventColors.TimeOff}; color: {EventColors.TextColor};";
        
        if (calendarEvent.IsCompanyWide)
            return $"background: {EventColors.CompanyWide}; color: {EventColors.TextColor};";
        
        if (!calendarEvent.IsApproved)
            return $"background: {EventColors.Pending}; color: {EventColors.TextColor};";
        
        if (calendarEvent.EmployeeId == _currentUserId)
            return $"background: {EventColors.UserEvent}; color: {EventColors.TextColor};";
        
        return $"background: {EventColors.AdminEvent}; color: {EventColors.TextColor};";
    }
    
    private void HandleLoadError(Exception ex)
    {
        _events = new List<CalendarEvent>();
        Console.WriteLine($"Error loading events: {ex.Message}");
    }
}