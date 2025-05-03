using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Departments.Commands.UpdateDepartment;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, BaseResponse<LeaveTypeDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveType> _repository;
        private readonly IMapper _mapper;
        public ILogger<UpdateLeaveTypeCommandHandler> _logger { get; }

        public UpdateLeaveTypeCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveType> repository, IMapper mapper, ILogger<UpdateLeaveTypeCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BaseResponse<LeaveTypeDto>> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Create a validator instance for the update request
            var validator = new UpdateLeaveTypeValidator();

            // Validate the request using the validator
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // ❌ If validation fails, log errors and return a failure response
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                // Log each validation error
                foreach (var error in errors)
                    _logger.LogError("Validation failed: {Error}", error);

                // Return failure response with error messages
                return BaseResponse<LeaveTypeDto>.FailureResult("Validation failed", errors);
            }

            try
            {
                // 🧠 Attempt to retrieve the existing entity from the repository
                var existingEntity = await _repository.GetByIdAsync(request.Id);

                // If the position does not exist, return a failure response
                if (existingEntity == null)
                {
                    return BaseResponse<LeaveTypeDto>.FailureResult("Position not found");
                }

                // Apply the updates to the existing entity using AutoMapper
                _mapper.Map(request.UpdateLeaveType, existingEntity);

                // Save the updated entity back to the repository
                await _repository.UpdateAsync(existingEntity);

                // Map the updated entity to a DTO for the response
                var updatedDto = _mapper.Map<LeaveTypeDto>(existingEntity);

                // Return a success response with the updated DTO
                return BaseResponse<LeaveTypeDto>.SuccessResult("Successfully updated.", updatedDto);
            }
            catch (Exception ex)
            {
                // 🛑 Log any unexpected error during the update process
                _logger.LogError("Unexpected error while updating position: {Message}", ex.Message);

                // Return a failure response for unexpected errors
                return BaseResponse<LeaveTypeDto>.FailureResult("An unexpected error occurred.");
            }
        }
    }
}
