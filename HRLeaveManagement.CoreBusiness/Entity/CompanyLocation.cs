using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    public class CompanyLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        // Navigation Property
        public ICollection<Employee> Employees { get; set; }
    }
}
