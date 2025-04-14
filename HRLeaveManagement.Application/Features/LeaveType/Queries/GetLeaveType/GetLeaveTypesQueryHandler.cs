using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.EmploymentType.Queries.GetEmploymentTypes;
using HRLeaveManagement.Application.Features.EmploymentType;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using HRLeaveManagement.Application.Features.Position;

namespace HRLeaveManagement.Application.Features.LeaveType.Queries.GetLeaveType
{

    public class GetLeaveTypesQueryHandler : IRequestHandler<GetLeaveTypesQuery, BaseResponse<List<LeaveTypeDto>>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveType> _repository;

        private readonly IMapper _mapper;

        public GetLeaveTypesQueryHandler(
            IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<List<LeaveTypeDto>>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all LeaveType
                var LeaveType = await _repository.GetAllAsync();
                if (LeaveType == null || LeaveType.Count==0)
                {
                    return BaseResponse<List<LeaveTypeDto>>.FailureResult("LeaveType not found.");

                }

                // Map entity list to DTO list
                var LeaveTypeDtos = _mapper.Map<List<LeaveTypeDto>>(LeaveType);

                // Return result with mapped data
                return BaseResponse<List<LeaveTypeDto>>.SuccessResult("EmploymentType retrieved successfully.", LeaveTypeDtos);
            }
            catch (Exception ex)
            {
                //_logger.LogError("Error retrieving all LeaveType: {Message}", ex.Message);
                return BaseResponse<List<LeaveTypeDto>>.FailureResult("An error occurred while retrieving EmploymentType.");
            }


        }
    }

}
