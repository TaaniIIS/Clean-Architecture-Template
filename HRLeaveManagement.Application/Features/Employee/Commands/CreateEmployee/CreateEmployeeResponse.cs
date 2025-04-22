using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;

namespace HRLeaveManagement.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeResponse :BaseResponse<EmployeeDto>
    {
        public int Id;
    }
}
