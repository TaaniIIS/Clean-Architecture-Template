using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;
using MediatR;
using static HRLeaveManagement.CoreBusiness.Entity.Shift;

namespace HRLeaveManagement.Application.Features.EmploymentType.Commands.CreateEmploymentType
{
    public class CreateEmploymentTypeCommand : IRequest<BaseResponse<ShiftDto>>
    {
        public ShiftDto Type { get; set; } // Only accepts enum values
    }
}
