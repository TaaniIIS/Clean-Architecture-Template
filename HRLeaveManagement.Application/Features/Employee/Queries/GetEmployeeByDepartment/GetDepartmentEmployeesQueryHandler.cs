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

namespace HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment
{
    public class GetDepartmentEmployeesQueryHandler : IRequestHandler<GetDepartmentEmployeesQuery, BaseResponse<List<EmployeeDto>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDepartmentEmployeesQueryHandler> _logger;

        public GetDepartmentEmployeesQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper, ILogger<GetDepartmentEmployeesQueryHandler> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BaseResponse<List<EmployeeDto>>> Handle(
        GetDepartmentEmployeesQuery request,
        CancellationToken cancellationToken)
        {
            try
            {
                //// Retrieve all positions
                //var employees = await _employeeRepository.GetEmployeeByDepartment();
                //// Map entity list to DTO list
                //var employeeDto = _mapper.Map<List<EmployeeDto>>(employees);
                //// Return result with mapped data
                //return BaseResponse<List<EmployeeDto>>.SuccessResult("Employees retrieved successfully", employeeDto);
                // 1. Get employees with department info
                var employees = await _employeeRepository.GetEmployeeByDepartment();

                // 2. Check if any employees exist
                if (employees == null || !employees.Any())
                {
                    _logger.LogWarning("No employees found when retrieving by department");
                    return BaseResponse<List<EmployeeDto>>.SuccessResult(
                        "No employees found",
                        new List<EmployeeDto>());
                }

                // 3. Map to DTO
                var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);

                // 4. Return successful response
                return BaseResponse<List<EmployeeDto>>.SuccessResult("Employees retrieved successfully", employeeDtos);


            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving Employee by Department: {Message}", ex.Message);
                return BaseResponse<List<EmployeeDto>>.FailureResult("An error occurred while retrieving Employee Departments.");
            }
        }

        }
}
