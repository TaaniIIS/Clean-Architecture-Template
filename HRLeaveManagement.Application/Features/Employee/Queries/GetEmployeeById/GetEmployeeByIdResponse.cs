using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdResponse : BaseResponse<EmployeeDto>
    {
        public EmployeeDto Department { get; set; }
    }
}
