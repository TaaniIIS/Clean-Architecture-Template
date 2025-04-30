using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQuery : IRequest<BaseResponse<EmployeeDto>>
    {
        public int Id { get; set; }
    }
    
}
