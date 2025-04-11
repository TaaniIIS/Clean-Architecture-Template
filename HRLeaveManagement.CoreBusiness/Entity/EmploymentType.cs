using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entity
{
    public class EmploymentType
    {
            public int EmploymentTypeID { get; set; }
            public string Name { get; set; } // Full-time, Part-time, etc.
            public ICollection<Employee> Employees { get; set; }
        
    }
}
