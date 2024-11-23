namespace HRApp.Models.Configuration;

public static class EmployeeConfigurations
{
    public static class FullTime
    {
        public const string BenefitsPackage = "Full Benefits";
        public const string ContractType = "Permanent";
        public const int WorkingHoursPerWeek = 40;
        public const bool IsOvertimeEligible = true;
        public const int VacationDaysPerYear = 25;
    }

    public static class PartTime
    {
        public const string BenefitsPackage = "Basic Benefits";
        public const string ContractType = "Part-Time";
        public const int WorkingHoursPerWeek = 20;
        public const bool IsOvertimeEligible = true;
        public const int VacationDaysPerYear = 12;
    }

    public static class Contractor
    {
        public const string BenefitsPackage = "Limited Benefits";
        public const string ContractType = "Fixed-Term";
        public const int WorkingHoursPerWeek = 40;
        public const bool IsOvertimeEligible = false;
        public const int VacationDaysPerYear = 0;
    }
    
    public static class Intern
    {
        public const string BenefitsPackage = "No Benefits";
        public const string ContractType = "Temporary";
        public const int WorkingHoursPerWeek = 20;
        public const bool IsOvertimeEligible = false;
        public const int VacationDaysPerYear = 0;
    }
}