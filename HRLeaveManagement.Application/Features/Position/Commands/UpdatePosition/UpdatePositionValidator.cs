using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Interfaces;

namespace HRLeaveManagement.Application.Features.Position.Commands.UpdatePosition
{
    public class UpdatePositionValidator : AbstractValidator<UpdatePositionCommand>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> _Repository;

        public UpdatePositionValidator(IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> repository)
        {
            _Repository = repository;

            RuleFor(x => x.Id)
             .GreaterThan(0)
             .WithMessage("Position ID must be greater than 0.");
            RuleFor(x => x.Id).MustAsync(CheckIfExist)
                .WithMessage("{PropertyName} Does not exist");
        }
        private async Task<bool> CheckIfExist(int positionId, CancellationToken cancellationToken)
        {
            var position = await _Repository.GetByIdAsync(positionId).ConfigureAwait(false);
            return position?.PositionID > 0;
        }
    }
}
