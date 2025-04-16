using HRLeaveManagement.Application.Features.LeaveRequest;
using System.Net.Http.Json;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;

namespace HRLeaveManagement.WebApp.Services
{
    public class PositionService : IPositionService
    {
        private readonly HttpClient _http;

        public PositionService(HttpClient http)
        {
            _http = http;
        }
        public async Task<List<PositionDto>> Get()
        {
            return await _http.GetFromJsonAsync<List<PositionDto>>("/Position/GetPosition");
        }
    }
}
