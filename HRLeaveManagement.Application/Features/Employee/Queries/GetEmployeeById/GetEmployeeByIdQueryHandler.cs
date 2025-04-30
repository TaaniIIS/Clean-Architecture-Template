using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Position.Queries.GetPositionById;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Response;
using MediatR;
using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, BaseResponse<EmployeeDto>>
    {
        private readonly IRepository<CoreBusiness.Entity.Employee> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEmployeeByIdQueryHandler> _logger;

        public GetEmployeeByIdQueryHandler(IRepository<CoreBusiness.Entity.Employee> repository, IMapper mapper, ILogger<GetEmployeeByIdQueryHandler> logger)
        {
            _repository = repository;  // For database access
            _mapper = mapper;          // For object mapping
            _logger = logger;          // For logging
        }
        public Task<BaseResponse<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
           // try
            {
                // Retrieve all employees
                var result = _repository.GetByIdAsync(request.Id);
                // Map entity list to DTO list
                var employeeDtos = _mapper.Map<EmployeeDto>(result);
                // Return result with mapped data
                return Task.FromResult(BaseResponse<EmployeeDto>.SuccessResult("Employees retrieved successfully.", employeeDtos));
            }
            //catch (Exception ex)
            //{
            //    _logger.LogError("Error retrieving all employees: {Message}", ex.Message);
            //    return Task.FromResult(BaseResponse<EmployeeDto>.FailureResult("An error occurred while retrieving employees."));
            //}
        }
    }
}
