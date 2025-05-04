using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    // Core/Entities/LeaveRequest.cs
    public class LeaveRequest
    {
        public int LeaveRequestID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending"; // Default status
        public string Description { get; set; }
        public int LeaveAmount { get; set; }
        public int DefaultDays { get; set; }
        // Foreign Keys
        public  int EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }

        // Navigation Properties
        public virtual Employee Employee { get; set; }
        public LeaveType  LeaveType { get; set; }


        public void ValidateRequest(LeaveType leaveType)
        {
            if (LeaveAmount > leaveType.DefaultDays)
                throw new InvalidOperationException(
                    $"Cannot request more than {leaveType.DefaultDays} days for {leaveType.Name} leave."
                );
        }
    }
}
