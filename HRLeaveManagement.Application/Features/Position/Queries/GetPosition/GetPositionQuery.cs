using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Position;
using MediatR;

namespace HRLeaveManagement.Application.Response
{
    public class GetPositionQuery : IRequest<BaseResponse<List<PositionDto>>>
    {
        public bool? IsActive { get; set; }  // Optional filter
       

    }
}
