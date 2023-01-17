using PaylocityAssessmentPayrollAPI.Entities;
using System.Collections.Generic;

namespace PaylocityAssessmentPayrollAPI.Interfaces
{
    public interface IEmployeePayrollDataAccess
    {        
        public IEnumerable<PayrollData> GetAllEmployeeInfo();
    }
}
