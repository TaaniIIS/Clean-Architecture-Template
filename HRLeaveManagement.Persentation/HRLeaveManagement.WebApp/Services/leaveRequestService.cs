using System.Net.Http;
using System.Net.Http.Json;
using HRLeaveManagement.Application.Features.Employee;
using HRLeaveManagement.Application.Features.LeaveRequest;
using HRLeaveManagement.Application.Features.LeaveType;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;
using HRLeaveManagement.WebApp.Model;
using static HRLeaveManagement.WebApp.Services.leaveRequestService;

namespace HRLeaveManagement.WebApp.Services
{
    public class leaveRequestService : IleaveRequestService
    {
        private readonly HttpClient _http;
        public leaveRequestService(HttpClient http)
        {
            _http = http;
        }



        public async Task<List<LeaveRequestViewModel>> GetLeaveRequests()
        {
            try
            {
                // Fetch all data in parallel
                var tasks = new Task[]
                {
                _http.GetFromJsonAsync<List<LeaveRequestViewModel>>("/api/LeaveRequest/Get"),
                _http.GetFromJsonAsync<List<EmployeeViewModel>>("/api/Employee/GetEmployee"),
                _http.GetFromJsonAsync<List<LeaveTypeViewModel>>("/api/LeaveType")
                };

                await Task.WhenAll(tasks);

                var leaveRequests = (tasks[0] as Task<List<LeaveRequestViewModel>>)?.Result ?? new List<LeaveRequestViewModel>();
                var employees = (tasks[1] as Task<List<EmployeeViewModel>>)?.Result ?? new List<EmployeeViewModel>();
                var leaveTypes = (tasks[2] as Task<List<LeaveTypeViewModel>>)?.Result ?? new List<LeaveTypeViewModel>();

                // LINQ query syntax with left joins
                var query = from lr in leaveRequests
                            join emp in employees on lr.EmployeeID equals emp.EmployeeID into empGroup
                            from employee in empGroup.DefaultIfEmpty() // Left join
                             join lt in leaveTypes on lr.LeaveTypeID equals lt.LeaveTypeID into ltGroup
                            from leaveType in ltGroup.DefaultIfEmpty() // Left join
                            select new LeaveRequestViewModel
                            {
                               // LeaveRequestID = lr.LeaveRequestID,
                                EmployeeID = lr.EmployeeID,
                                LeaveTypeID = lr.LeaveTypeID,
                                FullName = employee != null ? $"{employee.FirstName} {employee.LastName}" : "N/A",
                                EmployeeName = employee != null ? $"{employee.FirstName} {employee.LastName}" : "N/A",
                                LeaveTypeName = leaveType?.Name ?? "N/A",
                                PositionName = employee?.PositionName ?? "N/A",
                                shift = employee?.Shift ?? "N/A",
                                phone = employee?.Phone ?? 0,
                                StartDate = lr.StartDate,
                                EndDate = lr.EndDate,
                                Status = lr.Status ?? "Pending",
                                Description = lr.Description ?? string.Empty,
                                LeaveAmount = lr.LeaveAmount
                            };

                return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching leave requests: {ex.Message}");
                return new List<LeaveRequestViewModel>();
            }
        }

        public Task<BaseResponse<LeaveRequestViewModel>> GetLeaveRequestById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<BaseResponse<LeaveRequestViewModel>> CreateLeaveRequest(LeaveRequestViewModel leaveRequest)
        {
            var response = await _http.PostAsJsonAsync("/api/LeaveRequest", leaveRequest);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BaseResponse<LeaveRequestViewModel>>();
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error creating employee: {response.StatusCode} - {errorContent}");
                return null;
            }
        }

        public Task<BaseResponse<LeaveRequestViewModel>> UpdateLeaveRequest(int id, LeaveRequestViewModel leaveRequest)
        {
            throw new NotImplementedException();
        }
        public Task<BaseResponse<bool>> DeleteLeaveRequest(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
