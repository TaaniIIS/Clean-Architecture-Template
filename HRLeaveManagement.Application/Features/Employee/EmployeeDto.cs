using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.CoreBusiness.Entity;

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


        // Foreign Keys
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
        //public Department Department { get; set; }
        //public ICollection<WorkSchedule> WorkSchedules { get; set; }

    }
}
