using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HRLeaveManagement.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentValidator :AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentValidator()
        {
            RuleFor(x => x.CreateDepartment.Name)
              .NotEmpty()
              .WithMessage("Title is required.")
              .MaximumLength(100)
              .WithMessage("Title must be less than 100 characters.");
        }
    }
}
