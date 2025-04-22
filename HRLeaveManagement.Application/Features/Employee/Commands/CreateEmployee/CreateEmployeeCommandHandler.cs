using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse<EmployeeDto>>
    {
        private readonly IRepository<CoreBusiness.Entity.Employee> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateEmployeeCommandHandler> _logger;
        public CreateEmployeeCommandHandler(IRepository<CoreBusiness.Entity.Employee> repository, IMapper mapper, ILogger<CreateEmployeeCommandHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseResponse<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEmployeeValidator();
            var validationResult = validator.ValidateAsync(request, cancellationToken);
            // Return error response if validation fails
            if (!validationResult.Result.IsValid)
            {
                var errors = validationResult.Result.Errors.Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                    _logger.LogError("Validation failed: {Error}", error);
                return BaseResponse<EmployeeDto>.FailureResult("Validation failed", errors);
            }
            try
            {
                    _logger.LogInformation("Received command: {Command}",
                        JsonSerializer.Serialize(request));
                // Map DTO to domain entity
                var employeeEntity =_mapper.Map<CoreBusiness.Entity.Employee>(request.CreateEmployee);
                // Save to database
                var createdEntity = await _repository.AddAsync(employeeEntity);
                // Map entity back to DTO for returning
                var resultDto = _mapper.Map<EmployeeDto>(createdEntity);
                return BaseResponse<EmployeeDto>.SuccessResult("Employee created successfully", resultDto);
            }
            catch
            (Exception ex)
            {
                _logger.LogError("Error creating employee: {Message}", ex.Message);
                return BaseResponse<EmployeeDto>.FailureResult("An unexpected error occurred while creating the employee.");
            }

        }
    }
}




    /*
             public async Task<BaseResponse<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEmployeeValidator();
            var validationResult = validator.ValidateAsync(request, cancellationToken);
            // Return error response if validation fails
            if (!validationResult.Result.IsValid)
            {
                var errors = validationResult.Result.Errors.Select(e => e.ErrorMessage).ToList();
                foreach (var error in errors)
                    _logger.LogError("Validation failed: {Error}", error);
                return BaseResponse<EmployeeDto>.FailureResult("Validation failed", errors);
            }
            try
            {
                _logger.LogInformation("Received command: {Command}",
                JsonSerializer.Serialize(request));
                // Map DTO to domain entity
                var employeeEntity = new CoreBusiness.Entity.Employee
                {
                    FirstName = request.CreateEmployee.FirstName,
                    LastName = request.CreateEmployee.LastName,
                    Email = request.CreateEmployee.Email,
                };

                // Save to database
                var createdEntity = await _repository.AddAsync(employeeEntity);
                // Map entity back to DTO for returning
                var resultDto = new EmployeeDto
                {
                    Id = createdEntity.EmployeeID,
                    FirstName = createdEntity.FirstName,
                    LastName = createdEntity.LastName,
                    Email = createdEntity.Email,

                };
                return BaseResponse<EmployeeDto>.SuccessResult("Employee created successfully", resultDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error creating employee: {Message}", ex.Message);
                return BaseResponse<EmployeeDto>.FailureResult("An unexpected error occurred while creating the employee.");
            }

        }

     
     
     */