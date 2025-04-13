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

namespace HRLeaveManagement.Application.Features.Position.Queries.GetPositionById
{
    public class GetPositionByIdQueryHandler : IRequestHandler<GetPositionByIdQuery, BaseResponse<PositionDto>>
    {
        private readonly IRepository<CoreBusiness.Entity.Position> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPositionByIdQueryHandler> _logger;

        public GetPositionByIdQueryHandler(IRepository<CoreBusiness.Entity.Position> repository,IMapper mapper, ILogger<GetPositionByIdQueryHandler> logger )
        {
            _repository = repository;  // For database access
            _mapper = mapper;          // For object mapping
            _logger = logger;          // For logging
        }

        public async Task<BaseResponse<PositionDto>>
           Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all positions
                var result = await _repository.GetByIdAsync(request.Id);

                // Map entity list to DTO list
                var positionDtos = _mapper.Map<PositionDto>(result);

                // Return result with mapped data
                return BaseResponse<PositionDto>.SuccessResult("Positions retrieved successfully.", positionDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving all positions: {Message}", ex.Message);
                return BaseResponse<PositionDto>.FailureResult("An error occurred while retrieving positions.");
            }

        }
    }
}
