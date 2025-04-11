using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application.Features.Position
{
    public class PositionDto : BaseDto
    {
        public string? Title { get; set; }
        public string? JobLevel { get; set; }
        public bool IsActive { get; set; }
    }
}
