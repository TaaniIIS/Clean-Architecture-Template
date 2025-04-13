using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace HRLeaveManagement.Application.Features.Position.Commands.CreatePosition
{
    public class CreatePositionValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionValidator()
        {
            RuleFor(x => x.CreatePosition.Title)
                .NotEmpty()
                .WithMessage("Title is required.")
                .MaximumLength(100)
                .WithMessage("Title must be less than 100 characters.");

            RuleFor(x => x.CreatePosition.JobLevel)
                .NotEmpty()
                .WithMessage("Job Level is required.")
                .MaximumLength(50)
                .WithMessage("Job Level must be less than 50 characters.");

            RuleFor(x => x.CreatePosition.IsActive)
                .NotNull()
                .WithMessage("IsActive must be specified.");
        }
    }
}
