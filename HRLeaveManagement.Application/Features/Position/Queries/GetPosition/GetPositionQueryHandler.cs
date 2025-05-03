using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.Departments.Queries.GetDepartmentById;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using Web.Application.Features.Position.Queries.GetPosition;


namespace HRLeaveManagement.Application.Features.Position
{
    public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, BaseResponse<List<PositionDto>>>  // BaseResponse<List<PositionDto>>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetPositionQueryHandler> _logger;

        public GetPositionQueryHandler(
            IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> repository,
            IMapper mapper,
            ILogger<GetPositionQueryHandler> logger)
        {
            _repository = repository;  // For database access
            _mapper = mapper;          // For object mapping
            _logger = logger;          // For logging
        }

        public async Task<BaseResponse<List<PositionDto>>> Handle(GetPositionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all positions
                var positions = await _repository.GetAllAsync();

                // Map entity list to DTO list
                var positionDto = _mapper.Map<List<PositionDto>>(positions);

                // Return result with mapped data
                return BaseResponse<List<PositionDto>>.SuccessResult("Positions retrieved successfully.", positionDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error retrieving all positions: {Message}", ex.Message);
                return BaseResponse<List<PositionDto>>.FailureResult("An error occurred while retrieving positions.");
            }
        }

       
    }























    //public class GetPositionQueryHandler : IRequestHandler<GetPositionQuery, GetPositionResponse>
    //{
    //    private readonly IRepository<Domain.Entity.Position> _repository;
    //    private readonly IMapper _mapper;
    //    private readonly ILogger<GetPositionQueryHandler> _logger;

    //    public GetPositionQueryHandler(
    //        IRepository<Domain.Entity.Position> repository,
    //        IMapper mapper,
    //        ILogger<GetPositionQueryHandler> logger)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //        _logger = logger;
    //    }

    //    public async Task<GetPositionResponse> Handle(GetPositionQuery request,CancellationToken cancellationToken)
    //    {
    //        var response = new GetPositionResponse();

    //        try
    //        {
    //            // Get all positions (IReadOnlyList)
    //            var positions = await _repository.GetAllAsync();

    //            // Apply optional filtering
    //            var filteredPositions = request.IsActive.HasValue
    //                ? positions.Where(p => ((dynamic)p).IsActive == request.IsActive).ToList()
    //                : positions.ToList();

    //            response.Positions = _mapper.Map<List<PositionDto>>(filteredPositions);
    //            response.Success = true;
    //        }
    //        catch (Exception ex)
    //        {
    //            _logger.LogError(ex, "Error retrieving positions");
    //            response.Success = false;
    //            response.Message = "An error occurred while fetching positions";
    //        }

    //        return response;
    //    }
    //}
}
