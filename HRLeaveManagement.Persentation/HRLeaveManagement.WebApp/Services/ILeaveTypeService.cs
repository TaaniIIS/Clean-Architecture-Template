using HRLeaveManagement.Application.Response;
using HRLeaveManagement.WebApp.Model;

namespace HRLeaveManagement.WebApp.Services
{
    public interface ILeaveTypeService
    {
        Task<List<LeaveTypeViewModel>> GetAllAsync();

        Task<LeaveTypeViewModel> GetByIdAsync(int id);
        Task<BaseResponse<LeaveTypeViewModel>> CreateAsync(LeaveTypeViewModel leaveTypeViewModel);

        Task<bool> UpdateAsync(int id, LeaveTypeViewModel leaveTypeViewModel);
        Task<bool> DeleteAsync(int id);
    }
}
