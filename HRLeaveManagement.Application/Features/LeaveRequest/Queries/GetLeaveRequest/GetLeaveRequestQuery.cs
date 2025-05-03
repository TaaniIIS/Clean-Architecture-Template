using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest
{
    public class GetLeaveRequestQuery : IRequest<BaseResponse<List<LeaveRequestDto>>>
    {
        // add properties as needed
    }
}
