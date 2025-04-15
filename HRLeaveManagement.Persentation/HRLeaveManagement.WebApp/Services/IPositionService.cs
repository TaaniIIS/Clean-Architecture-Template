using HRLeaveManagement.Application.Features.Position;

namespace HRLeaveManagement.WebApp.Services
{
    public interface IPositionService
    {
        Task<List<PositionDto>> Get();
    }
}
