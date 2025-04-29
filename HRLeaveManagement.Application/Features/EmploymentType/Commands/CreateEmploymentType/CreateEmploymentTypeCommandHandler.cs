using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using static HRLeaveManagement.CoreBusiness.Entity.Shift;

namespace HRLeaveManagement.Application.Features.EmploymentType.Commands.CreateEmploymentType
{
    public class CreateEmploymentTypeCommandHandler : IRequestHandler<CreateEmploymentTypeCommand, BaseResponse<ShiftDto>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.Shift> _repository;
        private readonly ILogger<CreateEmploymentTypeCommand> _logger;
        public CreateEmploymentTypeCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.Shift> repository,ILogger<CreateEmploymentTypeCommand> logger )
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<BaseResponse<ShiftDto>> Handle(
                CreateEmploymentTypeCommand request,
                CancellationToken cancellationToken)
        {
            var response = new BaseResponse<ShiftDto>();

            try
            {
                // Validate enum value
                //if (!Enum.IsDefined(typeof(ShiftDto), request.Type))
                //{
                //    response.Success = false;
                //    response.Message = $"Invalid employment type. Valid options are between type  1 and 3:";  // {string.Join(", ", Enum.GetNames(typeof(EmploymentTypeEnum))}";
                //    response.ValidationErrors = new List<string> { response.Message };
                //    return response;
                //}

                var employmentType = new HRLeaveManagement.CoreBusiness.Entity.Shift {};
                await _repository.AddAsync(employmentType);

              //  response.Data = employmentType.Shifts;
                response.Success = true;
                response.Message = "Position created successfully";

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating employment type");
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
