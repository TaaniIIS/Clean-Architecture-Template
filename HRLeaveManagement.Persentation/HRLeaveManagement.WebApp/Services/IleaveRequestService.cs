using HRLeaveManagement.Application.Features.LeaveRequest;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.WebApp.Model;

namespace HRLeaveManagement.WebApp.Services
{
    public interface IleaveRequestService
    {
        Task<List<LeaveRequestViewModel>> GetLeaveRequests();
        Task<BaseResponse<LeaveRequestViewModel>> GetLeaveRequestById(int id);
        Task<BaseResponse<LeaveRequestViewModel>> CreateLeaveRequest(LeaveRequestViewModel leaveRequest);
        Task<BaseResponse<LeaveRequestViewModel>> UpdateLeaveRequest(int id, LeaveRequestViewModel leaveRequest);
        Task<BaseResponse<bool>> DeleteLeaveRequest(int id);
    }
}
