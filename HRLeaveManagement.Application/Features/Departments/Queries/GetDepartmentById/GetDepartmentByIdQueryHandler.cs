using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Features.Position.Queries.GetPositionById;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, BaseResponse<DepartmentDto>>
    {
        private readonly IRepository<CoreBusiness.Entity.Department> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDepartmentByIdQueryHandler> _logger;

        public GetDepartmentByIdQueryHandler(IRepository<CoreBusiness.Entity.Department> repository, IMapper mapper, ILogger<GetDepartmentByIdQueryHandler> logger)
        {
            _repository = repository;  // For database access
            _mapper = mapper;          // For object mapping
            _logger = logger;          // For logging
        }
        public async Task<BaseResponse<DepartmentDto>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all positions
                var result = await _repository.GetByIdAsync(request.Id);

                // Map entity list to DTO list
                var departmentDtos = _mapper.Map<DepartmentDto>(result);

                // Return result with mapped data
                return BaseResponse<DepartmentDto>.SuccessResult("Departments retrieved successfully.", departmentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving all Departments: {Message}", ex.Message);
                return BaseResponse<DepartmentDto>.FailureResult("An error occurred while retrieving Departments.");
            }

        }
    }
}
