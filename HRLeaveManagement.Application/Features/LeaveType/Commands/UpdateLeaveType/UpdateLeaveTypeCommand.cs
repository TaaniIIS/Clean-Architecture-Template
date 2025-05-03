using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommand : BaseCommandQuery, IRequest<BaseResponse<LeaveTypeDto>>
    {
        public LeaveTypeDto UpdateLeaveType { get; set; }
    }
}
