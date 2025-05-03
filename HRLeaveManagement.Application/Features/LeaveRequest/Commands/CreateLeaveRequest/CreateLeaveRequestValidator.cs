using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.CoreBusiness.Entity;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestCommand>
    {
        public CreateLeaveRequestValidator()
        {
            //RuleFor(x => x.createLRequest)
            //    .NotNull()
            //    .WithMessage("Leave request cannot be null");
            //RuleFor(x => x.createLRequest.LeaveAmount)
            //    .GreaterThan(0)
            //    .WithMessage("Leave amount must be greater than 0");
            //RuleFor(x => x.createLRequest.StartDate)
            //    .LessThan(x => x.createLRequest.EndDate)
            //    .WithMessage("Start date must be less than end date");
            //RuleFor(x => x.createLRequest.EmployeeID)
            //    .NotEmpty()
            //    .WithMessage("employee cannot be empty");
            //RuleFor(x => x.createLRequest.LeaveRequestId)
            //    .NotEmpty()
            //    .WithMessage("leave type cannot be empty");
            // check if the leave amount is less than the leave type amount
            //Rulefor(x => x.createLRequest.LeaveAmount)
            //    .LessThanOrEqualTo(x => x.createLRequest.LeaveTypeID)
            //    .WithMessage("Leave amount cannot be greater than leave type amount");

        }
    }
}
