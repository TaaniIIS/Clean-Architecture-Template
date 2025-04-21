using HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.WebApp.Model;

namespace HRLeaveManagement.WebApp.Services
{
    //public interface IPositionService<T> where T : class
    //IRepository<T> where T : class
    public interface IPositionService
    {
        Task<List<PositionViewModel>> GetAllAsync ();

        Task<PositionViewModel> GetByIdAsync(int id);
        Task<BaseResponse<PositionViewModel>> CreateAsync(PositionViewModel positionViewModel);

        Task<bool> UpdateAsync(int id,PositionViewModel positionViewModel);
        Task<bool> DeleteAsync(int id);




        //Task UpdateAsync(T entity);
        //Task DeleteAsync(T entity);
    }
}
