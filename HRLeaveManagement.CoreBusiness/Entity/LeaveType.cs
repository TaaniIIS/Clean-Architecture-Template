using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    public class LeaveType
    {
        public int LeaveTypeID { get; set; }
        public string Name { get; set; } // "Vacation", "Sick", etc.

        public int DefaultDays { get; set; }

        // Navigation Property
        public ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}
