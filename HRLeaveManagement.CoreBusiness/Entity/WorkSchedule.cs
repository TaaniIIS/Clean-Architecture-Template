using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    public class WorkSchedule
    {
        public int WorkScheduleID { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Foreign Key
        public int EmployeeID { get; set; }

        // Navigation Property
        public Employee Employee { get; set; }
    }
}
