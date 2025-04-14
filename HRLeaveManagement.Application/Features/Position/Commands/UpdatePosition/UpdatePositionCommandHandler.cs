using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Position.Commands.UpdatePosition
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, BaseResponse<PositionDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> _repository;
        private readonly IMapper _mapper;
        public ILogger<UpdatePositionCommandHandler> _logger { get; }

        public UpdatePositionCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> repository, IMapper mapper, ILogger<UpdatePositionCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        //I've highlighted key points like validation failure, data retrieval, applying updates, and error handling.
        //The comments explain each section of the method's logic to make it clearer for future developers or readers of the code.
        public async Task<BaseResponse<PositionDto>> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            // Create a validator instance for the update request
            var validator = new UpdatePositionValidator(_repository);

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
                return BaseResponse<PositionDto>.FailureResult("Validation failed", errors);
            }

            try
            {
                // 🧠 Attempt to retrieve the existing entity from the repository
                var existingEntity = await _repository.GetByIdAsync(request.Id);

                // If the position does not exist, return a failure response
                if (existingEntity == null)
                {
                    return BaseResponse<PositionDto>.FailureResult("Position not found");
                }

                // Apply the updates to the existing entity using AutoMapper
                _mapper.Map(request.UpdatePosition, existingEntity);

                // Save the updated entity back to the repository
                await _repository.UpdateAsync(existingEntity);

                // Map the updated entity to a DTO for the response
                var updatedDto = _mapper.Map<PositionDto>(existingEntity);

                // Return a success response with the updated DTO
                return BaseResponse<PositionDto>.SuccessResult("Successfully updated.", updatedDto);
            }
            catch (Exception ex)
            {
                // 🛑 Log any unexpected error during the update process
                _logger.LogError("Unexpected error while updating position: {Message}", ex.Message);

                // Return a failure response for unexpected errors
                return BaseResponse<PositionDto>.FailureResult("An unexpected error occurred.");
            }
        }

    }
}
