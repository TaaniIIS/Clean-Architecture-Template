using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Position.Commands.CreatePosition
{
    public class CreatePositionCommand :IRequest<BaseResponse<PositionDto>>
    {
        public PositionDto CreatePosition { get; set; }
    }
}
