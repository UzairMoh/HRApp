using HRApp.Models.Enums;

namespace HRApp.Models.Factories;

public interface IEmployeeFactory
{
    /// <summary>
    /// Creates an employee of the specified type with the given details
    /// </summary>
    Employees CreateEmployee(
        EmployeeType type,
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary);

    /// <summary>
    /// Creates a full-time employee with standard benefits and contract
    /// </summary>
    Employees CreateFullTimeEmployee(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary);

    /// <summary>
    /// Creates a part-time employee with adjusted benefits and hours
    /// </summary>
    Employees CreatePartTimeEmployee(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary);

    /// <summary>
    /// Creates a contractor with specific contract terms
    /// </summary>
    Employees CreateContractor(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary);

    /// <summary>
    /// Creates an intern with learning objectives and fixed term
    /// </summary>
    Employees CreateIntern(
        string firstName,
        string lastName,
        string email,
        string gender,
        string department,
        string salary);
}