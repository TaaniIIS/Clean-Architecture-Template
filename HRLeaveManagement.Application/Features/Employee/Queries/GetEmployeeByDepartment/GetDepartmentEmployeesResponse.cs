using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment
{
    public class GetDepartmentEmployeesResponse :BaseResponse<EmployeeDto>
    {
        public List<EmployeeDto> Employees { get; set; }
    }
}
