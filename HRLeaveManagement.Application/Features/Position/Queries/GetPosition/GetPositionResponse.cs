using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;

namespace Web.Application.Features.Position.Queries.GetPosition
{
    public class GetPositionResponse  : BaseResponse<PositionDto>
    {
        public List<PositionDto>? Positions { get; set; }
        
    }
}