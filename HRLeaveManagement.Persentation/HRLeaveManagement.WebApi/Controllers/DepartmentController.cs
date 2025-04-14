using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Departments.Commands.CreateDepartment;
using HRLeaveManagement.Application.Features.Position.Commands.UpdatePosition;
using HRLeaveManagement.Application.Features.Departments.Commands.UpdateDepartment;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.Application.Features.Departments.Queries.GetDepartment;
using HRLeaveManagement.Application.Features.Departments.Commands.DeleteDepartment;

namespace HRLeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ApiController
    {

        [HttpGet("GetDepartment")]
        public async Task<ActionResult<GetDepartmentResponse>> Get()
        {
            var response = await Mediator.Send(new GetDepartmentQuery());
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CreateDepartmentResponse>> Create(DepartmentDto commad)
        {

            var result = await Mediator.Send(new CreateDepartmentCommand() { CreateDepartment = commad });

            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<UpdateDepartmentResponse>> Update(int id, DepartmentDto commad)
        {
            var result = await Mediator.Send(new UpdateDepartmentCommand() { Id = id, UpdateDepartment = commad });
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<DeleteDepartmentResponse>> Delete(int id)
        {
            var result = await Mediator.Send(new DeleteDepartmentCommand() { Id = id });
            return Ok(result);
        }


    }
}
