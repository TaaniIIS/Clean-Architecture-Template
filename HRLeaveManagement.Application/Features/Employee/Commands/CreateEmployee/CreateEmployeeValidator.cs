using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HRLeaveManagement.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeValidator :AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeValidator() 
        {
            RuleFor(x => x.CreateEmployee.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");
            RuleFor(x => x.CreateEmployee.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");
            RuleFor(x => x.CreateEmployee.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
            //RuleFor(x => x.CreateEmployee.PhoneNumber)
            //    .NotEmpty().WithMessage("Phone Number is required.")
            //    .Matches(@"^\d{10}$").WithMessage("Phone Number must be 10 digits.");
        }

    }
}
