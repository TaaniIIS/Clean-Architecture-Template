using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployee
{
    public class GetEmployeeResponse : BaseResponse<EmployeeDto>
    {
        public List<EmployeeDto>? Positions { get; set; }

    }
}
