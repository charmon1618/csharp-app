using PaylocityAssessmentPayrollAPI.Controllers;
using PaylocityAssessmentPayrollAPI.Data_Access;
using PaylocityAssessmentPayrollAPI.Repositories;

namespace EmployeeTests
{
    public class EmployeePayrollTests
    {

        [Fact]
        public void DataAccessStubGeneratesEmployees()
        {
            var _employeePayrolllDataAccesss = new EmployeePayrollDataAccesss();

            var employeePayroll = _employeePayrolllDataAccesss.GetAllEmployeeInfo();
            Assert.NotNull(employeePayroll);
        }

        [Fact]
        public async Task RepositoryProcessesEmployeePaychecksAsync()
        {
            var _employeePayrollRepository = new EmployeePayrollRepository();

            var processedPayroll = await _employeePayrollRepository.GetAllEmployeePaychecks();

            Assert.NotNull(processedPayroll);
        }

        [Fact]
        public void ComputeSalaryWorks()         
        {
            var _employeePayrollRepository = new EmployeePayrollRepository();
            var computedSalary = _employeePayrollRepository.ComputeSalary(1000M, 26);
            
            Assert.Equal(26000M, computedSalary);
        }

        [Fact]
        public void ComputeBenefitsCostsWorks() 
        {
            var _employeePayrollRepository = new EmployeePayrollRepository();
            var computedBenefitCosts = _employeePayrollRepository.ComputeBenefitsCosts(true, 1000M);

            Assert.Equal(900M, computedBenefitCosts);
        }

        [Fact]
        public void ComputeDependentBenefitsCostsWorks() 
        {
            var _employeePayrollRepository = new EmployeePayrollRepository();
            var computedDependentBenefitsCosts = _employeePayrollRepository.ComputeDependentBenefitsCosts(1, 2, 500M);

            Assert.Equal(950M, computedDependentBenefitsCosts);

            var computedDependentBenefitsCosts2 = _employeePayrollRepository.ComputeDependentBenefitsCosts(0, 2, 500M);

            Assert.Equal(1000M, computedDependentBenefitsCosts2);

            var computedDependentBenefitsCosts3 = _employeePayrollRepository.ComputeDependentBenefitsCosts(2, 2, 500M);

            Assert.Equal(900M, computedDependentBenefitsCosts3);
        }
    }
}