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
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{

    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseResponse<LeaveTypeDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveType> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreatePositionCommandHandler> _logger;
        public CreateLeaveTypeCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveType> repository, IMapper mapper, ILogger<CreatePositionCommandHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseResponse<LeaveTypeDto>> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //var validator = new CreateLeaveTypeValidator();
            //var validationResult = await validator.ValidateAsync(request, cancellationToken);

            var leaveTypeEntity = _mapper.Map<HRLeaveManagement.CoreBusiness.Entity.LeaveType>(request.createLeave);

            // Save to database
            var createdEntity = await _repository.AddAsync(leaveTypeEntity);

            // Map entity back to DTO for returning
            var resultDto = _mapper.Map<LeaveTypeDto>(createdEntity);

            return BaseResponse<LeaveTypeDto>.SuccessResult("leave Type created successfully", resultDto);

            // Return error response if validation fails
            //if (!validationResult.IsValid)
            //{
            //    var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            //    foreach (var error in errors)
            //        _logger.LogError("Validation failed: {Error}", error);

            //    return BaseResponse<LeaveTypeDto>.FailureResult("Validation failed", errors);
            //}

            //try
            //{
            //    // Map DTO to domain entity
            //    var leaveTypeEntity = _mapper.Map<HRLeaveManagement.CoreBusiness.Entity.LeaveType>(request.createLeave);

            //    // Save to database
            //    var createdEntity = await _repository.AddAsync(leaveTypeEntity);

            //    // Map entity back to DTO for returning
            //    var resultDto = _mapper.Map<LeaveTypeDto>(createdEntity);

            //    return BaseResponse<LeaveTypeDto>.SuccessResult("leave Type created successfully", resultDto);
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError("Error creating leave Type: {Message}", ex.Message);
            //    return BaseResponse<LeaveTypeDto>.FailureResult("An unexpected error occurred while creating the position.");
            //}
        }
    }

}
