using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : BaseCommandQuery, IRequest<BaseResponse<DepartmentDto>>
    {
        public DepartmentDto UpdateDepartment { get; set; }
    }
}
