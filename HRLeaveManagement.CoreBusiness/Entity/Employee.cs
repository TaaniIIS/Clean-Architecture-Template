using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    // Core/Entities/Employee.cs
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        // Foreign Keys
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
   //     public int TeamID { get; set; }
        public int EmploymentTypeID { get; set; }
 //       public int? ManagerID { get; set; } // Nullable for top-level employees
    //    public int LocationID { get; set; }
        public int LeaveTypeID { get; set; }

        // Navigation Properties
        public Position? Position { get; set; }
        public Department? Department { get; set; }
     //   public Team? Team { get; set; }
        public EmploymentType? EmploymentType { get; set; }
 //       public Employee? Manager { get; set; }
    //    public CompanyLocation? Location { get; set; }
  //      public ICollection<Employee>? Subordinates { get; set; }
      //  public ICollection<LeaveRequest>? LeaveRequests { get; set; }
        public ICollection<WorkSchedule>? WorkSchedules { get; set; }
    }
}
