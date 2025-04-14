using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseResponse<DepartmentDto>>
    {
        private readonly IRepository<Department> _repository;
        private readonly IMapper _mapper;
        public ILogger<CreateDepartmentCommandHandler> _logger { get; }


        public CreateDepartmentCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.Department> repository, IMapper mapper, ILogger<CreateDepartmentCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }


        public async Task<BaseResponse<DepartmentDto>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDepartmentValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // Return error response if validation fails
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                    _logger.LogError("Validation failed: {Error}", error);

                return BaseResponse<DepartmentDto>.FailureResult("Validation failed", errors);
            }

            try
            {
                // Map DTO to domain entity
                var positionEntity = _mapper.Map<HRLeaveManagement.CoreBusiness.Entity.Department>(request.CreateDepartment);

                // Save to database
                var createdEntity = await _repository.AddAsync(positionEntity);

                // Map entity back to DTO for returning
                var resultDto = _mapper.Map<DepartmentDto>(createdEntity);

                return BaseResponse<DepartmentDto>.SuccessResult("New Department created successfully", resultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured while Department: {Message}", ex.Message);
                return BaseResponse<DepartmentDto>.FailureResult("An unexpected error occurred while Creating the New Department.");
            }

        }
    }
}
