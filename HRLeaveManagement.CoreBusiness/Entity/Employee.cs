using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        // ...other FKs...  
    }
}
