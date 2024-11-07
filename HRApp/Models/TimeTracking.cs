using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Models;

public enum EntryType
{
    Work,
    Holiday,
    SickLeave
}

public class TimeTrackingEntry
{
    [Key]
    public string Id { get; set; }

    [Required]
    public int EmployeeId { get; set; }

    [Required]
    public EntryType Type { get; set; }

    [MaxLength(250)]
    public string Text { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
    
}