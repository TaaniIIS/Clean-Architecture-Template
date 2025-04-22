using HRLeaveManagement.WebApp.Model;

namespace HRLeaveManagement.WebApp.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> Get();
        Task<EmployeeViewModel> GetById(int id);
        Task<EmployeeViewModel> Post(EmployeeViewModel employeeViewModel);
        Task<EmployeeViewModel> Put(int id, EmployeeViewModel employeeViewModel);
        Task<bool> Delete(int id);
        Task<List<EmployeeViewModel>> GetEmployeesByDepartment(int departmentId);
        Task<bool> EmployeeExists(string email);
        Task<List<EmployeeViewModel>> GetEmployeesByPosition(int positionId);
        Task<List<EmployeeViewModel>> GetEmployeesByLocation(int locationId);
        Task<List<EmployeeViewModel>> GetEmployeesByLeaveType(int leaveTypeId);
        Task<List<EmployeeViewModel>> GetEmployeesByEmploymentType(int employmentTypeId);

    }
}
