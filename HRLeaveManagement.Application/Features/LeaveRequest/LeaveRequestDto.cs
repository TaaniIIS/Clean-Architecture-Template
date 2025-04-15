using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveRequest
{
    public class LeaveRequestDto
    {
        //public int LeaveRequestID { get; set; }
        //public string Status { get; set; }
        //public int LeaveAmount { get; set; }

        //// Foreign Keys
        //public int EmployeeID { get; set; }
        //public int LeaveTypeID { get; set; }
        public int LeaveRequestId { get; set; }
        public int LeaveAmount { get; set; }

        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
    }
}
