using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.Employee;
using HRLeaveManagement.Application.Features.Position.Queries.GetPositionById;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequestById
{
    public class GetLeaveRequestByIdQueryHandler : IRequestHandler<GetLeaveRequestByIdQuery, BaseResponse<LeaveRequestDto>>
    {
        private readonly IRepository<CoreBusiness.Entity.LeaveRequest> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetLeaveRequestByIdQueryHandler> _logger;

        public GetLeaveRequestByIdQueryHandler(IRepository<CoreBusiness.Entity.LeaveRequest> repository, IMapper mapper, ILogger<GetLeaveRequestByIdQueryHandler> logger)
        {
            _repository = repository;  // For database access
            _mapper = mapper;          // For object mapping
            _logger = logger;          // For logging
        }
        public async Task<BaseResponse<LeaveRequestDto>> Handle(GetLeaveRequestByIdQuery request, CancellationToken cancellationToken)
        {
            // Implementation for handling the query
            try
            {
                // Retrieve all leave requests from the repository
                var leaveRequests = await _repository.GetByIdAsync(request.Id);

                if (leaveRequests == null) {
                    return BaseResponse<LeaveRequestDto>.FailureResult("No leave requests found.");
                }
                // map the leave requests to DTOs
                var leaveRequestDto = _mapper.Map<LeaveRequestDto>(leaveRequests);

                // return the result
                return BaseResponse<LeaveRequestDto>.SuccessResult("Leave requests retrieved successfully.", leaveRequestDto);



            }
            catch (Exception ex) 
            {
                _logger.LogError("Error retrieving leave request: {Message}", ex.Message);
                return BaseResponse<LeaveRequestDto>.FailureResult("An error occurred while retrieving the leave request.");

            }
        }
    }
}
