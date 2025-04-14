using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HRLeaveManagement.Application.Features.Departments.Queries.GetDepartment;
using HRLeaveManagement.Application.Features.Position.Commands.DeletePosition;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HRLeaveManagement.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, BaseResponse<DepartmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Department> _repository;
        private readonly ILogger<DeleteDepartmentCommandHandler> _logger;

        public DeleteDepartmentCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.Department> repository, IMapper mapper,ILogger<DeleteDepartmentCommandHandler> logger)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;

        }

        public async Task<BaseResponse<DepartmentDto>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Retrieve all Departments
                var Result = await _repository.GetByIdAsync(request.Id);
                if (Result == null)
                    return new DeleteDepartmentResponse { Success = false, Message = "Departments not found" };

                await _repository.DeleteAsync(Result);

                var PosEntity = _mapper.Map<DepartmentDto>(Result);
                // Return result with mapped data
                return BaseResponse<DepartmentDto>.SuccessResult("Departments deleted successfully.", PosEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occurred while deleting: {Message}", ex.Message);
                return BaseResponse<DepartmentDto>.FailureResult("An error occurred while deleting a Departments.");
            }

        }
    }
}
