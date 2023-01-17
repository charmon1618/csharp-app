using System.Collections.Generic;

namespace PaylocityAssessmentPayrollAPI.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }    
        public IEnumerable<EmployeeDependent> Dependents { get; set; }
    }
}
