using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;

namespace HRLeaveManagement.Application.Features.Position.Commands.CreatePosition
{
    public class CreatePositionResponse : BaseResponse<PositionDto>
    {
        public int Id;
    }
}
