using System.Net.Http.Json;
using HRLeaveManagement.WebApp.Model;
using static System.Net.WebRequestMethods;

namespace HRLeaveManagement.WebApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:5001/api/Employee";
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<EmployeeViewModel>> Get()
        {
            //try
            //{
            //    // /api/Employee/GetEmployee
            //    return await _httpClient.GetFromJsonAsync<List<EmployeeViewModel>>("/api/Employee/GetEmployee");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error fetching employees: {ex.Message}");
            //    return new List<EmployeeViewModel>();
            //}


            try
            {
                // Get employees and departments
                var employees = await _httpClient.GetFromJsonAsync<List<EmployeeViewModel>>("/api/Employee/GetEmployee");
                var departments = await _httpClient.GetFromJsonAsync<List<DepartmentViewModel>>("/api/Department/GetDepartment");
                var positions = await _httpClient.GetFromJsonAsync<List<PositionViewModel>>("/api/Position/GetPosition");
             

                // Join them to get department names
                var result = employees.Select(e => new EmployeeViewModel
                {
                    EmployeeID = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Email = e.Email,
                    DepartmentID = e.DepartmentID,
                    DepartmentName = departments.FirstOrDefault(d => d.Departmentid == e.DepartmentID)?.Name ?? "N/A",
                    PositionID = e.PositionID,
                    
                    PositionName = positions.FirstOrDefault(p => p.PositionId == e.PositionID)?.Title ?? "N/A",

                }).ToList();




                //var result = employees.Select(e => new EmployeeViewModel
                //{
                //    EmployeeID = e.EmployeeID,
                //    FirstName = e.FirstName,
                //    LastName = e.LastName,
                //    Email = e.Email,
                //    DepartmentID = e.DepartmentID,
                //    DepartmentName = departments.FirstOrDefault(d => d.Departmentid == e.DepartmentID)?.Name ?? "N/A"
                //}).ToList();

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employees with departments: {ex.Message}");
                return new List<EmployeeViewModel>();
            }





        }
        public async Task<EmployeeViewModel> GetById(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<EmployeeViewModel>($"/api/Employee/{id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching employee by ID: {ex.Message}");
                return null;
            }
        }
        public async Task<EmployeeViewModel> Put(int id, EmployeeViewModel employeeViewModel)
        {
            var response = await _httpClient.PutAsJsonAsync($"/api/Employee/{id}", employeeViewModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<EmployeeViewModel>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error updating employee: {response.StatusCode} - {errorContent}");
                return null;
            }
        }
        public async Task<EmployeeViewModel> Post(EmployeeViewModel employeeViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/Employee", employeeViewModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<EmployeeViewModel>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error creating employee: {response.StatusCode} - {errorContent}");
                return null;
            }
        }
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmployeeExists(string email)
        {
            throw new NotImplementedException();
        }

      

        public Task<List<EmployeeViewModel>> GetEmployeesByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetEmployeesByEmploymentType(int employmentTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetEmployeesByLeaveType(int leaveTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetEmployeesByLocation(int locationId)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeViewModel>> GetEmployeesByPosition(int positionId)
        {
            throw new NotImplementedException();
        }


    }
}
