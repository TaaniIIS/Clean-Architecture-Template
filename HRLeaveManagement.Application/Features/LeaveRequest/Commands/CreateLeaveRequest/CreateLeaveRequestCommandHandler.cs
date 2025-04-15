using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreatePositonCommand, BaseResponse<LeaveRequestDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveRequest> _repository;
        private readonly IEmployeeRepository _employeeRepo;
        //private readonly ILeaveTypeRepository _leaveTypeRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLeaveRequestCommandHandler> _logger;

        public CreateLeaveRequestCommandHandler(
            IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveRequest> repository,
            IEmployeeRepository employeeRepo,
            //ILeaveTypeRepository leaveTypeRepo,
            IMapper mapper,
            ILogger<CreateLeaveRequestCommandHandler> logger)
        {
            _repository = repository;
            _employeeRepo = employeeRepo;
            //_leaveTypeRepo = leaveTypeRepo;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BaseResponse<LeaveRequestDto>> Handle(CreatePositonCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            try
            {
                // Validate employee exists
                //var employee = await IEmployeeRepository.GetByIdAsync(request.EmployeeID);
                //if (employee == null)
                //{
                //    return BaseResponse<LeaveRequestDto>.FailureResult("Employee not found.");
                //}
                //return BaseResponse<DepartmentDto>.SuccessResult("New Department created successfully", resultDto);
                return BaseResponse<LeaveRequestDto>.FailureResult("Employee not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error Occured while Department: {Message}", ex.Message);
                return BaseResponse<LeaveRequestDto>.FailureResult("An unexpected error occurred while Creating the New Department.");
            }

        }
    }
}
