using HRLeaveManagement.Application.Features.Departments;
using HRLeaveManagement.Application.Features.Employee;
using HRLeaveManagement.Application.Response;
using HRLeaveManagement.WebApp.Model;

namespace HRLeaveManagement.WebApp.Services
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Gets all departments as a list of DepartmentDto objects
        /// </summary>
        /// <returns>List of DepartmentDto</returns>
        Task<List<DepartmentViewModel>> Get();

        /// <summary>
        /// Creates a new department
        /// </summary>
        /// <param name="departmentDto">Department data to create</param>
        /// <returns>BaseResponse containing the created DepartmentViewModel and status information</returns>
        Task<BaseResponse<DepartmentViewModel>> Post(DepartmentViewModel departmentViewModel);

        /// <summary>
        /// Gets a specific department by its ID
        /// </summary>
        /// <param name="id">Department ID to retrieve</param>
        /// <returns>BaseResponse containing the DepartmentDto if found</returns>
        Task<DepartmentDto> GetById(int id);

        /// <summary>
        /// Updates an existing department
        /// </summary>
        /// <param name="id">ID of the department to update</param>
        /// <param name="departmentDto">Updated department data</param>
        /// <returns>BaseResponse containing the updated DepartmentDto</returns>
        Task<BaseResponse<DepartmentDto>> Put(int id, DepartmentDto departmentViewModel);

        /// <summary>
        /// Deletes a department by its ID
        /// </summary>
        /// <param name="id">ID of the department to delete</param>
        /// <returns>BaseResponse with success/failure status</returns>
        Task<BaseResponse<bool>> Delete(int id);

        /// <summary>
        /// Gets all employees belonging to a specific department
        /// </summary>
        /// <param name="departmentId">Department ID to filter employees</param>
        /// <returns>List of EmployeeDto objects in the department</returns>
        Task<List<EmployeeDto>> GetEmployeesByDepartment(int departmentId);

        /// <summary>
        /// Checks if a department with the given name already exists
        /// </summary>
        /// <param name="name">Department name to check</param>
        /// <returns>True if department exists, false otherwise</returns>
        Task<bool> DepartmentExists(string name);
    }
}
