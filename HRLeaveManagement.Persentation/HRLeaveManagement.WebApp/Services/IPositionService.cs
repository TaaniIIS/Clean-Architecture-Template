using HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Response;

namespace HRLeaveManagement.WebApp.Services
{
    public interface IPositionService
    {
        Task<List<PositionDto>> Get();
        //Task<BaseResponse<PositionDto>> Post(CreatePositionCommand command);
        Task<BaseResponse<PositionDto>> Post(PositionDto positionDto);
    }
}
