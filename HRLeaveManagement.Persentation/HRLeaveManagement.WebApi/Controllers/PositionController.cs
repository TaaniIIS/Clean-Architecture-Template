using HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Features.Position.Queries.GetPosition;
using HRLeaveManagement.Application.Features.Position.Queries.GetPositionById;
using HRLeaveManagement.Application.Features.Position.Commands.DeletePosition;
using HRLeaveManagement.Application.Features.Position.Commands.UpdatePosition;

namespace HRLeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ApiController
    {
        [HttpGet("GetPosition")]
        public async Task<ActionResult<GetPositionResponse>> GetPosition()
        {
            var response = await Mediator.Send(new GetPositionQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPositionByIdResponse>> GetPosition(int id)
        {
            var result = await Mediator.Send(new GetPositionByIdQuery { Id = id });
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletePositionResponse>> Delete(int id)
        {
            var result = await Mediator.Send(new DeletePositionCommand() { Id = id });
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<UpdatePositionResponse>> Update(int id, PositionDto commad)
        {
            var result = await Mediator.Send(new UpdatePositionCommand() { Id = id, UpdatePosition = commad });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreatePositionResponse>> Create(PositionDto commad)
        {

            var result = await Mediator.Send(new CreatePositionCommand() { CreatePosition = commad });

            return Ok(result);
        }




        [HttpGet("GetEmployeeByDepart")]
        public async Task<ActionResult<GetDepartmentEmployeesResponse>> GetEmpByDepertment()
        {
            var response = await Mediator.Send(new GetDepartmentEmployeesQuery());
            return Ok(response);
        }


    }
}
