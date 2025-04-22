using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand :IRequest<BaseResponse<EmployeeDto>>
    {
        public EmployeeDto CreateEmployee { get; set; }
    }
}
