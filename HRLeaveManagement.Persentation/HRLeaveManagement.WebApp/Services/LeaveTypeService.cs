using System.Net.Http.Json;
using System.Text.Json;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.WebApp.Model;
using static System.Net.WebRequestMethods;

namespace HRLeaveManagement.WebApp.Services
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:5001/api/LeaveType";
        public LeaveTypeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<LeaveTypeViewModel>> GetAllAsync()
        {
            // The GetAllAsync method is an asynchronous method that retrieves a list of LeaveTypeViewModel objects.
            // It uses the HttpClient instance (_httpClient) to send a GET request to the API endpoint "/api/LeaveType/GetLeaveType".
            var response= await _httpClient.GetFromJsonAsync<List<LeaveTypeViewModel>>("/api/LeaveType");
            return response;//?.Data ?? new List<LeaveTypeViewModel>();

        }

        public Task<LeaveTypeViewModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseResponse<LeaveTypeViewModel>> CreateAsync(LeaveTypeViewModel leaveTypeViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync<LeaveTypeViewModel>("/api/LeaveType", leaveTypeViewModel);
            var result = await response.Content.ReadAsStringAsync();
            var createLeaveTypeResponse = JsonSerializer.Deserialize<BaseResponse<LeaveTypeViewModel>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return createLeaveTypeResponse;
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<bool> UpdateAsync(int id, LeaveTypeViewModel leaveTypeViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
