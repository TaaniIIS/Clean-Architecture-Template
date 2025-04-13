using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;

namespace HRLeaveManagement.Application.Features.Position.Queries.GetPositionById
{
    public class GetPositionByIdResponse : BaseResponse<PositionDto>
    {
        public PositionDto Position { get; set; }
    }
}
