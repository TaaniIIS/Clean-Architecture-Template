using System.Net.Http.Json;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Employee;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.WebApp.Model;

namespace HRLeaveManagement.WebApp.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;

        public DepartmentService(HttpClient http)
        {
            _http = http;
        }

        

        //public async Task<List<DepartmentDto>> Get()
        //{
        //    return await _http.GetFromJsonAsync<List<DepartmentDto>>("/api/Department/");
        //}

        public async Task<List<DepartmentViewModel>> Get()
        {
            try
            {///api/Department/GetDepartment
                return await _http.GetFromJsonAsync<List<DepartmentViewModel>>("/api/Department/GetDepartment");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching departments: {ex.Message}");
                return new List<DepartmentViewModel>();
            }
        }

        public Task<DepartmentDto> GetById(int id)
        {
            try
            {
                return _http.GetFromJsonAsync<DepartmentDto>($"/api/Department/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching department by ID: {ex.Message}");
                return Task.FromResult<DepartmentDto>(null);
            }
        }

     

        public async Task<BaseResponse<DepartmentViewModel>> Post(DepartmentViewModel positionDto)
        {
            // Correct way to use PostAsJsonAsync
            var response = await _http.PostAsJsonAsync("/api/Department", positionDto);

            // Ensure we handle the response properly
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BaseResponse<DepartmentViewModel>>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new BaseResponse<DepartmentViewModel>
                {
                    Success = false,
                    Message = $"API Error: {response.StatusCode} - {errorContent}"
                };
            }
        }

        public Task<BaseResponse<DepartmentDto>> Put(int id, DepartmentDto departmentViewModel)
        {
            var response = _http.PutAsJsonAsync($"/api/Department/{id}", departmentViewModel);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadFromJsonAsync<BaseResponse<DepartmentDto>>();
            }
            else
            {
                var errorContent = response.Result.Content.ReadAsStringAsync();
                return Task.FromResult(new BaseResponse<DepartmentDto>
                {
                    Success = false,
                    Message = $"API Error: {response.Result.StatusCode} - {errorContent}"
                });
            }
        }

        public Task<BaseResponse<bool>> Delete(int id)
        {
            var response = _http.DeleteAsync($"/api/Department/{id}");
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadFromJsonAsync<BaseResponse<bool>>();
            }
            else
            {
                var errorContent = response.Result.Content.ReadAsStringAsync();
                return Task.FromResult(new BaseResponse<bool>
                {
                    Success = false,
                    Message = $"API Error: {response.Result.StatusCode} - {errorContent}"
                });
            }
        }

        public Task<bool> DepartmentExists(string name)
        {
            var response = _http.GetAsync($"/api/Department/Exists?name={name}");
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadFromJsonAsync<bool>();
            }
            else
            {
                var errorContent = response.Result.Content.ReadAsStringAsync();
                return Task.FromResult(false);
            }
        }
        public Task<List<EmployeeDto>> GetEmployeesByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

      
    }
}
