using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestById
{
    public class GetLeaveRequestByIdResponse : BaseResponse<LeaveRequestDto>
    {
        public LeaveRequestDto LeaveRequest { get; set; } = new LeaveRequestDto();
    }
}
