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

namespace HRLeaveManagement.Application.Features.Position.Commands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, BaseResponse<PositionDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePositionCommandHandler> _logger;
        public CreatePositionCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> repository , IMapper mapper, ILogger<CreatePositionCommandHandler> logger )
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseResponse<PositionDto>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreatePositionValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // Return error response if validation fails
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                    _logger.LogError("Validation failed: {Error}", error);

                return BaseResponse<PositionDto>.FailureResult("Validation failed", errors);
            }

            try
            {
                // Map DTO to domain entity
                var positionEntity = _mapper.Map<HRLeaveManagement.CoreBusiness.Entity.Position>(request.CreatePosition);

                // Save to database
                var createdEntity = await _repository.AddAsync(positionEntity);

                // Map entity back to DTO for returning
                var resultDto = _mapper.Map<PositionDto>(createdEntity);

                return BaseResponse<PositionDto>.SuccessResult("Position created successfully", resultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating position: {Message}", ex.Message);
                return BaseResponse<PositionDto>.FailureResult("An unexpected error occurred while creating the position.");
            }
        }
    }
}
