using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.EmploymentType;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveType
{
    public class GetLeaveTypesQuery : IRequest<BaseResponse<List<LeaveTypeDto>>>
    {
    }
}
