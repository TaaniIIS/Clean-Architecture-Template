using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
   
        // Core/Entities/Team.cs
        public class Team
        {
            public int TeamID { get; set; }
            public string Name { get; set; }

            // Foreign Keys
            public int DepartmentID { get; set; }
            public int ManagerID { get; set; }

            // Navigation Properties
            public Department Department { get; set; }
            public Employee Manager { get; set; }
            public ICollection<Employee> Members { get; set; }
        }
    
}
