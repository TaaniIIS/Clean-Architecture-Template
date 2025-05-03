using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequest
{
    public class LeaveRequestDto
    {

        public int LeaveRequestId { get; set; }
        public int LeaveAmount { get; set; }

        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
    }
}
