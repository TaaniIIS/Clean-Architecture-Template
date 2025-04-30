using HRLeaveManagement.Application.Features.Employee;
using HRLeaveManagement.Application.Features.Employee.Commands.CreateEmployee;
using HRLeaveManagement.Application.Features.Employee.Queries.GetEmployee;
using HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRLeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ApiController
    {
        [HttpGet("GetEmployee")]
        public async Task<ActionResult<GetEmployeeResponse>> GetEmployee()
        {
            var response = await Mediator.Send(new GetEmployeeQuery());
            return Ok(response.Data);
        }

        [HttpPost("CreateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CreateEmployeeResponse>> CreateEmployee([FromBody] EmployeeDto command)
        {
            var response = await Mediator.Send(new CreateEmployeeCommand { CreateEmployee = command });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeByIdResponse>> GetEmployee(int id)
        {
            var result = await Mediator.Send(new GetEmployeeByIdQuery { Id = id });
            return Ok(result);
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<DeleteEmployeeResponse>> Delete(int id)
        //{
        //    var result = await Mediator.Send(new DeleteEmployeeCommand() { Id = id });
        //    return Ok(result);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult<UpdateEmployeeResponse>> Update(int id, EmployeeDto commad)
        //{
        //    var result = await Mediator.Send(new UpdateEmployeeCommand() { Id = id, UpdateEmployee = commad });
        //    return Ok(result);
        //}
    }
}
