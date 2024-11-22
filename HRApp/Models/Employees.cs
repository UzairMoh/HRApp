﻿using System.ComponentModel.DataAnnotations;

namespace HRApp.Models
{
    /// <summary>
    /// Represents an employee in the HR application.
    /// </summary>
    public sealed class Employees
    {
        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        [StringLength(10, ErrorMessage = "Gender cannot be longer than 10 characters.")]
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        [StringLength(50, ErrorMessage = "Department cannot be longer than 50 characters.")]
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        [StringLength(20, ErrorMessage = "Salary cannot be longer than 20 characters.")]
        public string? Salary { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of time off requests for the employee.
        /// </summary>
        public ICollection<TimeOffRequest>? TimeOffRequests { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee joined the company.
        /// This field is required and represents the employee's start date.
        /// </summary>
        [Required(ErrorMessage = "Join date is required.")]
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee left the company.
        /// This field is nullable as it only applies to former employees.
        /// </summary>
        public DateTime? LeaveDate { get; set; }

        /// <summary>
        /// Gets a value indicating whether the employee is currently active.
        /// An employee is considered active if they have not left the company.
        /// </summary>
        public bool IsActive => !LeaveDate.HasValue;
    }
}