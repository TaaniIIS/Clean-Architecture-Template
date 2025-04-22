using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, BaseResponse<List<EmployeeDto>>>
    {
        private readonly IRepository<CoreBusiness.Entity.Employee> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetEmployeeQueryHandler> _logger;
        public GetEmployeeQueryHandler(IRepository<CoreBusiness.Entity.Employee> repository, IMapper mapper, ILogger<GetEmployeeQueryHandler> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<BaseResponse<List<EmployeeDto>>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all employees
                var employees = await _repository.GetAllAsync();
                // Map entity list to DTO list
                var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
                // Return result with mapped data
                return BaseResponse<List<EmployeeDto>>.SuccessResult("Employees retrieved successfully.", employeeDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving all employees: {Message}", ex.Message);
                // Return error response
                return BaseResponse<List<EmployeeDto>>.FailureResult("An error occurred while retrieving positions.");

            }
        }
    }
}
