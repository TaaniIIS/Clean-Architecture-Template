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
    public class GetEmploymentTypesQueryHandler : IRequestHandler<GetEmploymentTypesQuery, BaseResponse<List<ShiftDto>>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Shift> _repository;

        private readonly IMapper _mapper;

        public GetEmploymentTypesQueryHandler(
            IRepository<HRLeaveManagement.CoreBusiness.Entity.Shift> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<ShiftDto>>> Handle(GetEmploymentTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all EmploymentType
                var EmploymentType = await _repository.GetAllAsync();

                // Map entity list to DTO list
                var positionDtos = _mapper.Map<List<ShiftDto>>(EmploymentType);

                // Return result with mapped data
                return BaseResponse<List<ShiftDto>>.SuccessResult("EmploymentType retrieved successfully.", positionDtos);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error retrieving all positions: {Message}", ex.Message);
                return BaseResponse<List<ShiftDto>>.FailureResult("An error occurred while retrieving EmploymentType.");
            }


        }
    }
}
