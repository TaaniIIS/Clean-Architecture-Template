using System.Net.Http.Json;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Employee;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;

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

        public async Task<List<DepartmentDto>> Get()
        {
            try
            {///api/Department/GetDepartment
                return await _http.GetFromJsonAsync<List<DepartmentDto>>("/api/Department/GetDepartment");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching departments: {ex.Message}");
                return new List<DepartmentDto>();
            }
        }


        public async Task<BaseResponse<DepartmentDto>> Post(DepartmentDto positionDto)
        {
            // Correct way to use PostAsJsonAsync
            var response = await _http.PostAsJsonAsync("/api/Department", positionDto);

            // Ensure we handle the response properly
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BaseResponse<DepartmentDto>>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                return new BaseResponse<DepartmentDto>
                {
                    Success = false,
                    Message = $"API Error: {response.StatusCode} - {errorContent}"
                };
            }
        }

        public Task<BaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DepartmentExists(string name)
        {
            throw new NotImplementedException();
        }

       

        public Task<BaseResponse<DepartmentDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeDto>> GetEmployeesByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }


        public Task<BaseResponse<DepartmentDto>> Update(int id, DepartmentDto departmentDto)
        {
            throw new NotImplementedException();
        }
    }
}
