namespace HRApp.Models.Enums;

/// <summary>
/// Represents the different types of employment within the organization.
/// </summary>
public enum EmployeeType
{
    /// <summary>
    /// Represents a full-time employee with standard benefits and working hours.
    /// </summary>
    FullTime,

    /// <summary>
    /// Represents a part-time employee with pro-rated benefits and reduced working hours.
    /// </summary>
    PartTime,

    /// <summary>
    /// Represents a contractor with fixed-term contract and limited benefits.
    /// </summary>
    Contractor,

    /// <summary>
    /// Represents an intern with temporary placement and learning objectives.
    /// </summary>
    Intern
}