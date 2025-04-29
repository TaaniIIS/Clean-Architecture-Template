using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using static HRLeaveManagement.CoreBusiness.Entity.Shift;

namespace HRLeaveManagement.Application.Features.EmploymentType.Commands.CreateEmploymentType
{
    public class CreateEmploymentTypeValidator : AbstractValidator<CreateEmploymentTypeCommand>
    {
        public CreateEmploymentTypeValidator()
        {
            ////RuleFor(x => x.Type)
            ////    .IsInEnum() // Ensures only valid enum values
            ////    .WithMessage("Invalid employment type");
            //RuleFor(x => x.Type)
            //.Must(x => Enum.IsDefined(typeof(ShiftDto), x))
            //.WithMessage("Invalid employment type. Valid options are: " +
            //    string.Join(", ", Enum.GetNames(typeof(ShiftDto))));
        }
    }
}
