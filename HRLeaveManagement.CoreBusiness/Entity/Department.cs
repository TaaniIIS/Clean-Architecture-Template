using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    // Core/Entities/Department.cs
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("createdDate")] // Ensures consistent naming
        public DateTime CreatedDate { get; set; }

        // Navigation Properties
        public ICollection<Employee> Employees { get; set; }
    }
}
