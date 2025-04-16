using HRLeaveManagement.Application.Features.LeaveRequest;
using System.Net.Http.Json;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRLeaveManagement.Application.Response;
using System.Text.Json;

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
            return await _http.GetFromJsonAsync<List<PositionDto>>("/api/Position/GetPosition");
            //return await _http.GetFromJsonAsync<List<PositionDto>>("/Position/GetPosition");
        }


        public async Task<BaseResponse<PositionDto>> Post(PositionDto positionDto)
        {
            // Correct way to use PostAsJsonAsync
            var response = await _http.PostAsJsonAsync("/api/Position", positionDto);

            // Ensure we handle the response properly
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BaseResponse<PositionDto>>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new BaseResponse<PositionDto>
                {
                    Success = false,
                    Message = $"API Error: {response.StatusCode} - {errorContent}"
                };
            }
        }

    }
}
