using PaylocityAssessmentPayrollAPI.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaylocityAssessmentPayrollAPI.Interfaces
{
    public interface IEmployeePayrollRepository
    {
        public Task<PayrollDTO> GetAllEmployeePaychecks();
    }
}
