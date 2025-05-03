using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        public UpdateLeaveTypeValidator() 
        {
        }
    }
}
