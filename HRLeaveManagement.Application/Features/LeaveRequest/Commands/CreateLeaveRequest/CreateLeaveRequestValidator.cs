using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestValidator : AbstractValidator<CreatePositonCommand>
    {
        public CreateLeaveRequestValidator()
        {
            //RuleFor(x => x.createLeaveRequest.EmployeeID)
            //  .NotEmpty()
            //  .WithMessage("Title is required.")
            //  .MaximumLength(100)
            //  .WithMessage("Title must be less than 100 characters.");
        }
    }
}
