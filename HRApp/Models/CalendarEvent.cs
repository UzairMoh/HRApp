using System.ComponentModel.DataAnnotations;

namespace HRApp.Models;

/// <summary>
/// Represents a calendar event in the HR application.
/// </summary>
public class CalendarEvent
{
    /// <summary>
    /// Gets or sets the unique identifier for the calendar event.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the event.
    /// </summary>
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the description of the event.
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the start date and time of the event.
    /// </summary>
    [Required(ErrorMessage = "Start date is required.")]
    public DateTime Start { get; set; }

    /// <summary>
    /// Gets or sets the end date and time of the event.
    /// </summary>
    [Required(ErrorMessage = "End date is required.")]
    public DateTime End { get; set; }

    /// <summary>
    /// Gets or sets whether the event is company-wide.
    /// </summary>
    public bool IsCompanyWide { get; set; }

    /// <summary>
    /// Gets or sets the employee ID associated with this event (null if company-wide).
    /// </summary>
    public int? EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the employee associated with this event.
    /// </summary>
    public virtual Employees? Employee { get; set; }
}