using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.Employee
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Shift { get; set; }

        public int Phone { get; set; }
        //  public string Title { get; set; }

        public int phone { get; set; }

        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
      //  public int LeaveTypeID { get; set; }

    }
}
