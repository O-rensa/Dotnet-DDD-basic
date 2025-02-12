using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllEmployees()
        {
            return Ok();
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            return Ok();
        }

        [HttpPost("createEmployee")]
        public async Task<IActionResult> CreateEmployee()
        {
            return Ok();
        }

        [HttpPut("updateEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee(Guid employeeId)
        {
            return Ok();
        }

        [HttpDelete("deleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee(Guid employeeId)
        {
            return Ok();
        }
    }
}
