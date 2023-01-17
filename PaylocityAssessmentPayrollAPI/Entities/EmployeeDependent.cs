namespace PaylocityAssessmentPayrollAPI.Entities
{
    public class EmployeeDependent
    {
        public int EmployeeId { get; set; }
        public int EmployeeDependentId { get; set; }
        public string Name { get; set; }    
        public int Age { get; set; }
        public string DependentType { get; set; }
    }
}
