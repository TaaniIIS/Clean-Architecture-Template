using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Position.Commands.DeletePosition
{
    public class DeletePositionCommand : BaseCommandQuery, IRequest<BaseResponse<PositionDto>> //IRequest<DeletePositionResponse>
    {
     
    }
}
