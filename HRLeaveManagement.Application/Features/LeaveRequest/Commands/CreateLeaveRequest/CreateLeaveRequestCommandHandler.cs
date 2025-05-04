using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Departments.Commands.CreateDepartment;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;
using MediatR;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseResponse<LeaveRequestDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveRequest> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLeaveRequestCommandHandler> _logger;

        public CreateLeaveRequestCommandHandler(
            IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveRequest> repository,
            IMapper mapper,
            ILogger<CreateLeaveRequestCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BaseResponse<LeaveRequestDto>> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            

            // Return error response if validation fails
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                    _logger.LogError("Validation failed: {Error}", error);
                     
                return BaseResponse<LeaveRequestDto>.FailureResult("Validation failed", errors);
            }

            // get leave amount by leave type id
            var leaveType = await _repository.GetByIdAsync(request.createLRequest.LeaveTypeID);




            // Check if leaveAmount is less than or equal to default days
            //if (request.createLRequest.LeaveAmount > leaveType.DefaultDays)
            //{
            //    return BaseResponse<LeaveRequestDto>.FailureResult("Leave amount cannot be greater than leave type amount.");
            //}

            try
            {
                // Map DTO to domain entity
                var LeaveRequestEntity = _mapper.Map<HRLeaveManagement.CoreBusiness.Entity.LeaveRequest>(request.createLRequest);

                // Save to database
                var createdEntity = await _repository.AddAsync(LeaveRequestEntity);

                // Map entity back to DTO for returning
                var resultDto = _mapper.Map<LeaveRequestDto>(createdEntity);

                return BaseResponse<LeaveRequestDto>.SuccessResult("New leave created successfully", resultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured while leave: {Message}", ex.Message);
                return BaseResponse<LeaveRequestDto>.FailureResult("An unexpected error occurred while Creating the New leave.");
            }


        }
    }
}
