using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    // Core/Entities/Department.cs
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        // Navigation Properties
       // public ICollection<Team> Teams { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
