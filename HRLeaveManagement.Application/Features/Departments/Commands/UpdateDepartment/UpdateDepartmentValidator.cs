using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HRLeaveManagement.Application.Interfaces;

namespace HRLeaveManagement.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Department> _Repository;

        public UpdateDepartmentValidator(IRepository<HRLeaveManagement.CoreBusiness.Entity.Department> repository)
        {
            _Repository = repository;

            RuleFor(x => x.Id)
             .GreaterThan(0)
             .WithMessage("Position ID must be greater than 0.");
            RuleFor(x => x.Id).MustAsync(CheckIfExist)
                .WithMessage("{PropertyName} Does not exist");
        }
        private async Task<bool> CheckIfExist(int departmentid, CancellationToken cancellationToken)
        {
            var department = await _Repository.GetByIdAsync(departmentid).ConfigureAwait(false);
            return department?.DepartmentID > 0;
        }
    }
}
