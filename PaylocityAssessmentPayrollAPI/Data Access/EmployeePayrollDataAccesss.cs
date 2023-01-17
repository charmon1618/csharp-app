using PaylocityAssessmentPayrollAPI.Entities;
using PaylocityAssessmentPayrollAPI.Interfaces;
using System.Collections.Generic;
using System.Xml.Linq;

namespace PaylocityAssessmentPayrollAPI.Data_Access
{
    public class EmployeePayrollDataAccesss : IEmployeePayrollDataAccess
    {
        public IEnumerable<PayrollData> GetAllEmployeeInfo()
        {
            //CORS took up time, and I ran into version conflicts with SQLlite, stub it is.
            var employeePaychecks = new List<PayrollData>
            {
                new PayrollData { Id = 1, Employee =
                new Employee {
                    EmployeeId = 1,
                    EmployeeName = "Alice",
                    EmployeeAge = 30,
                    Dependents = new List<EmployeeDependent>()
                    {
                        new EmployeeDependent {
                            EmployeeId = 1,
                            EmployeeDependentId = 2,
                            Name = "Alicia",
                            Age  = 10,
                            DependentType = "Child" },
                        new EmployeeDependent {
                            EmployeeId = 1,
                            EmployeeDependentId = 3,
                            Name = "Bob",
                            Age  = 31,
                            DependentType = "Spouse"
                        }
                    }
                }, 
                BasePayPerPeriod = 2000M,
                PayPeriodsPerYear = 26},

                new PayrollData { Id = 2, Employee = 
                new Employee { 
                    EmployeeId = 2, 
                    EmployeeName = "Tom", 
                    EmployeeAge = 32, 
                    Dependents = new List<EmployeeDependent>()}, 
                    BasePayPerPeriod = 2000M,
                    PayPeriodsPerYear = 26
                },

                new PayrollData { Id = 3, Employee = 
                new Employee { 
                    EmployeeId = 3, 
                    EmployeeName = "Harry", 
                    EmployeeAge = 33, 
                    Dependents = new List<EmployeeDependent>(){new EmployeeDependent {
                            EmployeeId = 3,
                            EmployeeDependentId = 4,
                            Name = "Ann",
                            Age  = 32,
                            DependentType = "Spouse"
                        } 
                    } 
                },                 
                BasePayPerPeriod = 2000M,
                PayPeriodsPerYear = 26}
            };
            return employeePaychecks;
        }
    }
}
