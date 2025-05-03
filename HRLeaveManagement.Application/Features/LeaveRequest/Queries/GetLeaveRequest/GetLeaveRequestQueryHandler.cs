using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.LeaveRequest.Queries.GetLeaveRequest
{
    public class GetLeaveRequestQueryHandler : IRequestHandler<GetLeaveRequestQuery, BaseResponse<List<LeaveRequestDto>>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveRequest> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetLeaveRequestQueryHandler> _logger;
        public GetLeaveRequestQueryHandler(
            IRepository<HRLeaveManagement.CoreBusiness.Entity.LeaveRequest> repository,
            IMapper mapper,
            ILogger<GetLeaveRequestQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BaseResponse<List<LeaveRequestDto>>> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
        {
            // Implementation for handling the query
            try
            {
                // Retrieve all leave requests from the repository
                var leaveRequests = await _repository.GetAllAsync();
                if (leaveRequests == null || leaveRequests.Count == 0)
                {
                    return BaseResponse<List<LeaveRequestDto>>.FailureResult("No leave requests found.");
                }

                // map the leave requests to DTOs
                var leaveRequestDtos = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);

                // return the result
                return BaseResponse<List<LeaveRequestDto>>.SuccessResult("Leave requests retrieved successfully.", leaveRequestDtos);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving leave request: {Message}", ex.Message);
                return BaseResponse<List<LeaveRequestDto>>.FailureResult("An error occurred while retrieving the leave request.");
            }
        }
    }

}
