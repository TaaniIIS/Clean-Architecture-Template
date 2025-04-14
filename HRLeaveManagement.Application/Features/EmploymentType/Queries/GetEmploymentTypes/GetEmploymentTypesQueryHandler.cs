using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;
using MediatR;

namespace HRLeaveManagement.Application.Features.EmploymentType.Queries.GetEmploymentTypes
{
    public class GetEmploymentTypesQueryHandler : IRequestHandler<GetEmploymentTypesQuery, BaseResponse<List<EmploymentTypeDto>>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.EmploymentType> _repository;

        private readonly IMapper _mapper;

        public GetEmploymentTypesQueryHandler(
            IRepository<HRLeaveManagement.CoreBusiness.Entity.EmploymentType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<EmploymentTypeDto>>> Handle(GetEmploymentTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all EmploymentType
                var EmploymentType = await _repository.GetAllAsync();

                // Map entity list to DTO list
                var positionDtos = _mapper.Map<List<EmploymentTypeDto>>(EmploymentType);

                // Return result with mapped data
                return BaseResponse<List<EmploymentTypeDto>>.SuccessResult("EmploymentType retrieved successfully.", positionDtos);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error retrieving all positions: {Message}", ex.Message);
                return BaseResponse<List<EmploymentTypeDto>>.FailureResult("An error occurred while retrieving EmploymentType.");
            }


        }
    }
}
