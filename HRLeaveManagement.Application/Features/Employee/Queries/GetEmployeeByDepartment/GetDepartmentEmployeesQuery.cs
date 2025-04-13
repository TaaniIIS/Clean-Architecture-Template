using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment
{
    public class GetDepartmentEmployeesQuery : IRequest<BaseResponse<List<EmployeeDto>>>   //IRequest<GetDepartmentEmployeesResponse>
    {
        public int? DepartmentId { get; set; } // Optional filter
    }
}
