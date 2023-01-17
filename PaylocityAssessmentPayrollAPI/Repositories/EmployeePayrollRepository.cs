using PaylocityAssessmentPayrollAPI.Data_Access;
using PaylocityAssessmentPayrollAPI.DTO;
using PaylocityAssessmentPayrollAPI.Entities;
using PaylocityAssessmentPayrollAPI.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaylocityAssessmentPayrollAPI.Repositories
{
    public class EmployeePayrollRepository : IEmployeePayrollRepository
    {
        private readonly IEmployeePayrollDataAccess _employeePayrollDataAccess;

        //CORS took so much time I didn't want to register the services for DI. 
        //Pretend I did.
        public EmployeePayrollRepository()
        {
            _employeePayrollDataAccess = new EmployeePayrollDataAccesss();
        }

        public async Task<PayrollDTO> GetAllEmployeePaychecks() 
        {
            var employeeInfo = _employeePayrollDataAccess.GetAllEmployeeInfo();

            return await Task.Run(()=> ProcessEmployeePaychecks(employeeInfo));
        }

        public PayrollDTO ProcessEmployeePaychecks(IEnumerable<PayrollData> employeeInfo) 
        {
            var payrollDTO = new PayrollDTO();
            payrollDTO.Data = new List<Payroll>();
            foreach (var payrollData in employeeInfo) 
            {
                //My preference, personally, is to make things extremely obvious and self documenting
                //Obviously the norms of a given team or shop take precedence
                var basePayPerPeriod = payrollData.BasePayPerPeriod;
                var payPeriodsPerYear = payrollData.PayPeriodsPerYear;
                var dependentCount = payrollData.Employee.Dependents.Count();
                var isEmployeeADiscounted = payrollData.Employee.EmployeeName.StartsWith("A");
                var dependentADiscounts = payrollData.Employee.Dependents.Count(d => d.Name.StartsWith("A"));

                const int benefitCostPerEmployeePerYear = 1000;
                const int benefitCostPerDependentPerYear = 500;

                //Stepping through into this method was not working, didn't want to waste time 
                //So, methods!
                var salaryPerYear = ComputeSalary(basePayPerPeriod, payPeriodsPerYear);
                var employeeBenefitsCostPerYear = ComputeBenefitsCosts(isEmployeeADiscounted, benefitCostPerEmployeePerYear);
                var dependentBenefitCostPerYear = ComputeDependentBenefitsCosts(dependentADiscounts, dependentCount, benefitCostPerDependentPerYear);

                payrollDTO.Data.Add(new Payroll
                {
                    Id = payrollData.Id,
                    Name = payrollData.Employee.EmployeeName,
                    Pay = ((salaryPerYear - employeeBenefitsCostPerYear - dependentBenefitCostPerYear) / 26M).ToString("n2")
                });
            }
            return payrollDTO;
        }

        public decimal ComputeSalary(decimal basePayPerPeriod, int payPeriodsPerYear) 
        {
            var totalSalary = basePayPerPeriod * payPeriodsPerYear;
            return totalSalary;
        }

        public decimal ComputeBenefitsCosts(bool isEmployeeADiscounted, decimal benefitCostPerEmployeePerYear) 
        {
            var employeeBenefitsCostPerYear = isEmployeeADiscounted ? 
                    (benefitCostPerEmployeePerYear * .9M) :
                    (benefitCostPerEmployeePerYear);

            return employeeBenefitsCostPerYear;
        }

        public decimal ComputeDependentBenefitsCosts(int dependentADiscounts, int dependentCount, decimal benefitCostPerDependentPerYear)
        {
            var dependentBenefitCostPerYear = (dependentADiscounts > 0) ?
                    ((dependentCount * benefitCostPerDependentPerYear) - (benefitCostPerDependentPerYear * 0.1M * dependentADiscounts)) :
                    (dependentCount * benefitCostPerDependentPerYear);

            return dependentBenefitCostPerYear;
        }
    }
}
