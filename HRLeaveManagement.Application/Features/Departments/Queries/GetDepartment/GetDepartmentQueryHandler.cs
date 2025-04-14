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

namespace HRLeaveManagement.Application.Features.Departments.Queries.GetDepartment
{
    public class GetDepartmentQueryHandler : IRequestHandler<GetDepartmentQuery, BaseResponse<List<DepartmentDto>>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Department> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDepartmentQueryHandler> _logger;

        public GetDepartmentQueryHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.Department> repository,IMapper mapper,ILogger<GetDepartmentQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BaseResponse<List<DepartmentDto>>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all departments
                var departments = await _repository.GetAllAsync();

                // Map entity list to DTO list
                var departmentDtos = _mapper.Map<List<DepartmentDto>>(departments);

                // Return result with mapped data
                return BaseResponse<List<DepartmentDto>>.SuccessResult("departmentS retrieved successfully.", departmentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving all departmentS: {Message}", ex.Message);
                return BaseResponse<List<DepartmentDto>>.FailureResult("An error occurred while retrieving departmentS.");
            }

        }
    }
}
