using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.LeaveType
{
    public class LeaveTypeDto 
    {
        public int LeaveTypeID { get; set; } // 1, 2, 3, etc.
        public string Name { get; set; } // "Vacation", "Sick", etc.

        public int DefaultDays { get; set; } // 10, 15, etc.
    }
}
