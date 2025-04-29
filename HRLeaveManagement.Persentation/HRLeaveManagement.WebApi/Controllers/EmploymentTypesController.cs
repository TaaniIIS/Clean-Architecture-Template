using HRLeaveManagement.Application.Features.Departments.Commands.CreateDepartment;
using HRLeaveManagement.Application.Features.EmploymentType;
using HRLeaveManagement.Application.Features.EmploymentType.Commands.CreateEmploymentType;
using HRLeaveManagement.Application.Features.EmploymentType.Queries.GetEmploymentTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static HRLeaveManagement.CoreBusiness.Entity.Shift;

namespace HRLeaveManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentTypesController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<ShiftDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetEmploymentTypesQuery());
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create(CreateEmploymentTypeCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result); 
        }


    }
}
