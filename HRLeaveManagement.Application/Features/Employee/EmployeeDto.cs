using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.Employee
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        //  public string Title { get; set; }

        // Foreign Keys
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
        //     public int TeamID { get; set; }
        public int EmploymentTypeID { get; set; }
        //       public int? ManagerID { get; set; } // Nullable for top-level employees
     //   public int LocationID { get; set; }
        public int LeaveTypeID { get; set; }

    }
}
