using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.CoreBusiness.Entity;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Position.Commands.DeletePosition
{
    public class DetelePositionCommandHandler : IRequestHandler<DeletePositionCommand, BaseResponse<PositionDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> _repository;
        private readonly ILogger<DetelePositionCommandHandler> _logger;
        public IMapper _Mapper { get; }
        public DetelePositionCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.Position> repository, IMapper mapper, ILogger<DetelePositionCommandHandler> logger )
        {
            _repository=repository;
            _Mapper=mapper;
            _logger=logger;
        }
        public async Task<BaseResponse<PositionDto>> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all positions
                var Result = await _repository.GetByIdAsync(request.Id);
                if (Result == null)
                    return new DeletePositionResponse { Success = false, Message = "Position not found" };

                await _repository.DeleteAsync(Result);

                var PosEntity = _Mapper.Map<PositionDto>(Result);
                // Return result with mapped data
                return BaseResponse<PositionDto>.SuccessResult("Positions deleted successfully.", PosEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while deleting: {Message}", ex.Message);
                return BaseResponse<PositionDto>.FailureResult("An error occurred while deleting a position.");
            }
        }

    }
}
