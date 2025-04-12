using HRLeaveManagement.Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Application.Features.Position.Queries.GetPosition;

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


    }
}
