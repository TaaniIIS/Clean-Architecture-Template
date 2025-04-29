using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.Departments
{
    public class DepartmentDto 
    {
        public int Departmentid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateOnly CreatedDate { get; set; }
    }
}
