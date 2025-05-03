using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestById
{
    public class GetLeaveRequestByIdQuery : IRequest<BaseResponse<LeaveRequestDto>>
    {
        public int Id { get; set; }
    }
}
