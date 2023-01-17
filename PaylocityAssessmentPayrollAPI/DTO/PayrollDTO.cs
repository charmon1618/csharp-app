using System.Collections.Generic;

namespace PaylocityAssessmentPayrollAPI.DTO
{
    public class PayrollDTO
    {
        public List<Payroll> Data { get; set; }
    }

    public class Payroll 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pay { get; set; }
    }
}
