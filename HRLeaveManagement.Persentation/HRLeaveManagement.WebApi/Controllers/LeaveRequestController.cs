using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Features.Position.Queries.GetPositionById;
using HRLeaveManagement.Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Features.Position.Queries.GetPosition;
using HRLeaveManagement.Application.Features.Position.Commands.UpdatePosition;
using HRLeaveManagement.Application.Features.Position.Commands.DeletePosition;
using HRLeaveManagement.CoreBusiness.Entity;
using HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRLeaveManagement.Application.Features.LeaveType;
using HRLeaveManagement.Application.Features.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest;
using HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestById;

namespace HRLeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ApiController
    {
        [HttpGet("Get")]
        public async Task<ActionResult<GetLeaveRequestResponse>> Get()
        {
            var response = await Mediator.Send(new GetLeaveRequestQuery());
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetLeaveRequestByIdResponse>> GetById(int id)
        {
             var result = await Mediator.Send(new GetLeaveRequestByIdQuery { Id = id });
            return Ok(result.Data);
        }
        [HttpPost]
        public async Task<ActionResult<CreateLeaveRequestResponse>> Post(LeaveRequestDto commad)
        {

            var result = await Mediator.Send(new CreateLeaveRequestCommand() { createLRequest = commad });

            return Ok(result);
        }
        //[HttpPut("{id}")]
        //public async Task<ActionResult<UpdatePositionResponse>> PUT(int id, PositionDto commad)
        //{
        //    var result = await Mediator.Send(new UpdatePositionCommand() { Id = id, UpdatePosition = commad });
        //    return Ok(result);
        //}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<DeletePositionResponse>> Delete(int id)
        //{
        //    var result = await Mediator.Send(new DeletePositionCommand() { Id = id });
        //    return Ok(result);
        //}
    }
}
