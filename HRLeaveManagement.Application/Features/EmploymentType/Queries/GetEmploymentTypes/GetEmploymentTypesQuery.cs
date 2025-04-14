using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.EmploymentType.Queries.GetEmploymentTypes
{
    public sealed record GetEmploymentTypesQuery : IRequest<BaseResponse<List<EmploymentTypeDto>>>
    {

    }
}
