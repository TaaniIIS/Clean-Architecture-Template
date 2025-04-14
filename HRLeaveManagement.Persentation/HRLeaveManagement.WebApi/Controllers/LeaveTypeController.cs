using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.EmploymentType;
using HRLeaveManagement.Application.Features.EmploymentType.Commands.CreateEmploymentType;
using HRLeaveManagement.Application.Features.EmploymentType.Queries.GetEmploymentTypes;
using HRLeaveManagement.Application.Features.LeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveType;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRLeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ApiController
    {
        // GET: api/<LeaveTypeController>
        [HttpGet]
        [ProducesResponseType(typeof(List<LeaveTypeDto>), 200)]
        public async Task<IActionResult> Get()
        {
            var result = await Mediator.Send(new GetLeaveTypesQuery());
            return Ok(result);
        }
        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("LeaveType");
        }
        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateLeaveTypeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result); 
        }
        // PUT api/<LeaveTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
