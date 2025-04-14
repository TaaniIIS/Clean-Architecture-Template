using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Departments.Queries.GetDepartment
{
    public class GetDepartmentQuery : IRequest<BaseResponse<List<DepartmentDto>>>
    {

    }

}
