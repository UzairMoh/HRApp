using System.ComponentModel.DataAnnotations;
using HRApp.Models.Enums.Employee;

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
        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email address of the employee.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the gender of the employee.
        /// </summary>
        [Required(ErrorMessage = "Gender is required.")]
        public Gender Gender { get; set; }

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        [Required(ErrorMessage = "Department is required.")]
        public Department Department { get; set; }
        
        /// <summary>
        /// Gets or sets the employment type of the employee.
        /// This determines the employee's contract type, benefits eligibility, and work arrangements.
        /// </summary>
        [Required(ErrorMessage = "Contract type is required.")]
        public ContractType ContractType { get; set; }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        [Required(ErrorMessage = "Salary is required.")]
        [RegularExpression(@"^\d{1,10}(\.\d{1,2})?$", ErrorMessage = "Invalid salary format. Use numbers with up to 2 decimal places.")]
        public decimal Salary { get; set; }
        
        /// <summary>
        /// Gets or sets the collection of time off requests for the employee.
        /// </summary>
        public ICollection<TimeOffRequest>? TimeOffRequests { get; set; }
        
        /// <summary>
        /// Gets or sets the benefits package assigned to the employee.
        /// </summary>
        [Required(ErrorMessage = "Benefits package is required.")]
        public BenefitsPackage BenefitsPackage { get; set; }

        /// <summary>
        /// Gets or sets the working hours per week for the employee.
        /// </summary>
        [Range(1, 168, ErrorMessage = "Working hours must be between 1 and 168 per week.")]
        public int WorkingHoursPerWeek { get; set; }

        /// <summary>
        /// Gets or sets whether the employee is eligible for overtime.
        /// </summary>
        public bool IsOvertimeEligible { get; set; }

        /// <summary>
        /// Gets or sets the vacation days per year the employee is entitled to.
        /// </summary>
        [Range(0, 365, ErrorMessage = "Vacation days must be between 0 and 365.")]
        public int VacationDaysPerYear { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee joined the company.
        /// </summary>
        [Required(ErrorMessage = "Join date is required.")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        /// <summary>
        /// Gets or sets the date when the employee left the company.
        /// This field is nullable as it only applies to former employees.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime? LeaveDate { get; set; }

        /// <summary>
        /// Gets a value indicating whether the employee is currently active.
        /// </summary>
        public bool IsActive => !LeaveDate.HasValue;

        /// <summary>
        /// Gets the full name of the employee.
        /// </summary>
        public string FullName => $"{FirstName} {LastName}";
        
        internal Employees() { }
    }
}