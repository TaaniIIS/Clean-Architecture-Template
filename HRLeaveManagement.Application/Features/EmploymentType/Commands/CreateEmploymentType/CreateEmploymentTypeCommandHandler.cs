using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.Application.Response;
using MediatR;
using Microsoft.Extensions.Logging;
using static HRLeaveManagement.CoreBusiness.Entity.EmploymentType;

namespace HRLeaveManagement.Application.Features.EmploymentType.Commands.CreateEmploymentType
{
    public class CreateEmploymentTypeCommandHandler : IRequestHandler<CreateEmploymentTypeCommand, BaseResponse<int>>
    {
        private readonly IRepository<HRLeaveManagement.CoreBusiness.Entity.EmploymentType> _repository;
        private readonly ILogger<CreateEmploymentTypeCommand> _logger;
        public CreateEmploymentTypeCommandHandler(IRepository<HRLeaveManagement.CoreBusiness.Entity.EmploymentType> repository,ILogger<CreateEmploymentTypeCommand> logger )
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<BaseResponse<int>> Handle(
                CreateEmploymentTypeCommand request,
                CancellationToken cancellationToken)
        {
            var response = new BaseResponse<int>();

            try
            {
                // Validate enum value
                if (!Enum.IsDefined(typeof(EmploymentTypeEnum), request.Type))
                {
                    response.Success = false;
                    response.Message = $"Invalid employment type. Valid options are between type  1 and 3:";  // {string.Join(", ", Enum.GetNames(typeof(EmploymentTypeEnum))}";
                    response.ValidationErrors = new List<string> { response.Message };
                    return response;
                }

                var employmentType = new HRLeaveManagement.CoreBusiness.Entity.EmploymentType { Type = request.Type };
                await _repository.AddAsync(employmentType);

                response.Data = employmentType.EmploymentTypeID;
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
