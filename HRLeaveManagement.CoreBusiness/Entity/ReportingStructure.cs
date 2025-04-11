using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    public class ReportingStructure
    {
        public int EmployeeId { get; set; }
        public int? ManagerId { get; set; } // Nullable for top-level  
        public Employee Employee { get; set; }
    }
}
