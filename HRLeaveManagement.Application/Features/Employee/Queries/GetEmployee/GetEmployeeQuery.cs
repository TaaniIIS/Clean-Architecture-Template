using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using MediatR;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployee
{
    public class GetEmployeeQuery : IRequest<BaseResponse<List<EmployeeDto>>>
    {
        public List<EmployeeDto>? Positions { get; set; }
        //  additional query paramerters.
        //public bool? IsActive { get; set; }  // Optional filter
        //public string? SearchTerm { get; set; } // Optional search term
        //public int? DepartmentId { get; set; } // Optional department filter
        //public int? PositionId { get; set; } // Optional position filter
        //public int? LeaveTypeId { get; set; } // Optional leave type filter
        //public int? EmployeeId { get; set; } // Optional employee ID filter
        // Add any other filters or parameters as needed
    }
}
