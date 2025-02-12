using Application.Employees.Commands;
using Application.Employees.Dtos;
using Application.Employees.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeeController(
                ISender sender
            )
        {
            _sender = sender;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _sender.Send(new GetAllEmployeeQuery());

            return Ok(result);
        }

        [HttpGet("getEmployee/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute]Guid employeeId)
        {
            var result = await _sender.Send(new GetEmployeeByIdQuery(employeeId));

            return Ok(result);
        }

        [HttpPost("createEmployee")]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateOrEditEmployeeDto employee)
        {
            var result = await _sender.Send(new CreateEmployeeCommand(employee));

            return Ok(result);
        }

        [HttpPut("updateEmployee/{employeeId}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute]Guid employeeId, [FromBody] CreateOrEditEmployeeDto employee)
        {
            employee.Id = employeeId;
            var result = await _sender.Send(new UpdateEmployeeCommand(employee));

            return Ok(result);
        }

        [HttpDelete("deleteEmployee/{employeeId}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]Guid employeeId)
        {
            var result = await _sender.Send(new DeleteEmployeeCommand(employeeId));

            return Ok(result);
        }
    }
}
