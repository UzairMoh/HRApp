using System.ComponentModel.DataAnnotations;
using HRApp.Models.Enums;

namespace HRApp.Models;

/// <summary>
/// Represents a time off request in the HR application.
/// </summary>
public class TimeOffRequest
{
    /// <summary>
    /// Gets or sets the unique identifier for the time off request.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the employee ID associated with this request.
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the employee associated with this request.
    /// </summary>
    public virtual Employees? Employee { get; set; }

    /// <summary>
    /// Gets or sets the start date of the time off request.
    /// </summary>
    [Required(ErrorMessage = "Start date is required.")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the time off request.
    /// </summary>
    [Required(ErrorMessage = "End date is required.")]
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the type of time off request.
    /// </summary>
    [Required(ErrorMessage = "Time off type is required.")]
    public TimeOffType Type { get; set; }

    /// <summary>
    /// Gets or sets the description or reason for the time off request.
    /// </summary>
    [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the status of the request.
    /// </summary>
    public RequestStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the creation date of the request.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
