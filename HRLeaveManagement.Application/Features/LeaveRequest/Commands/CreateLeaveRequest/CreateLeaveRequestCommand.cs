using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand :  IRequest<BaseResponse<LeaveRequestDto>> 
    {
        public int EmployeeID { get; set; }
        public LeaveRequestDto createLeaveRequest { get; set; }
    }
}
