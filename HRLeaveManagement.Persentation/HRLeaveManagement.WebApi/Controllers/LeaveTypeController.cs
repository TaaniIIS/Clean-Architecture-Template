using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.EmploymentType;
using HRLeaveManagement.Application.Features.EmploymentType.Commands.CreateEmploymentType;
using HRLeaveManagement.Application.Features.EmploymentType.Queries.GetEmploymentTypes;
using HRLeaveManagement.Application.Features.LeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveType;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Features.Position;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;

namespace HRLeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ApiController
    {
        // GET: api/<LeaveTypeController>
        [HttpGet]
       // [ProducesResponseType(typeof(List<CreateLeaveTypeResponse>), 200)]
        public async Task<ActionResult<GetLeaveTypeResponse>> Get()
        {
            var result = await Mediator.Send(new GetLeaveTypesQuery());
            return Ok(result.Data);
        }
      
        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<ActionResult<CreateLeaveTypeCommand>> Create(LeaveTypeDto commad)
        {
            var result = await Mediator.Send(new CreateLeaveTypeCommand() { createLeave = commad });
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
