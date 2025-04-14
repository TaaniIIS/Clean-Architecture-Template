using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.EmploymentType
{
    public class EmploymentTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } // Auto-maps from enum
    }
}
