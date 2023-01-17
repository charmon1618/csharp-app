using System;

namespace PaylocityAssessmentPayrollAPI.Entities
{
    public class PayrollData
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public decimal BasePayPerPeriod { get; set; }   
        public int PayPeriodsPerYear { get; set; }
    }
}
