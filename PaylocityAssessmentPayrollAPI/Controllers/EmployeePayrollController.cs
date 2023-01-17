using Microsoft.AspNetCore.Mvc;
using PaylocityAssessmentPayrollAPI.Interfaces;
using PaylocityAssessmentPayrollAPI.Repositories;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaylocityAssessmentPayrollAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePayroll : ControllerBase
    {

        private readonly IEmployeePayrollRepository _employeePayrollRepository;
        public EmployeePayroll() 
        {
            _employeePayrollRepository = new EmployeePayrollRepository();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var ret = await _employeePayrollRepository.GetAllEmployeePaychecks();
            return new JsonResult(ret);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
