using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Position.Commands.UpdatePosition
{
    public class UpdatePositionCommand : BaseCommandQuery, IRequest<BaseResponse<PositionDto>>
    {
        public PositionDto UpdatePosition { get; set; }

    }
}
