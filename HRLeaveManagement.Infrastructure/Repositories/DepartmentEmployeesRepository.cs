using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.Application.Features.Employee;
using HRLeaveManagement.Application.Features.Employee.Queries.GetEmployeeByDepartment;
using HRLeaveManagement.Application.Interfaces;
using HRLeaveManagement.CoreBusiness.Entity;
using Microsoft.EntityFrameworkCore;

namespace HRLeaveManagement.Infrastructure.Repositories
{
    public class DepartmentEmployeesRepository : Repository<Employee>, IEmployeeRepository
    {
        public DepartmentEmployeesRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<List<Employee>> GetEmployeeByDepartment()
        {
            return await _applicationDbContext.Employees
                .Include(e => e.Department)  // Eager load department data
            .OrderBy(e => e.Department.Name)  // Sort by department name
            .ThenBy(e => e.LastName)  // Then by employee last name
            .ToListAsync();


            //    return await _applicationDbContext.Employees
            //.Include(e => e.Department)  // Load Department data
            //.Include(e => e.Position)    // Load Position data
            //.OrderBy(e => e.Department.Name)  // Sort by department
            //.ThenBy(e => e.Position.Title)    // Then by position title
            //.ThenBy(e => e.LastName)          // Then by employee last name
            //.ToListAsync();



        }


        //public async Task<List<EmployeeDepartmentDto>> GetEmployeeByDepartmentDto()
        //{
        //    return await _applicationDbContext.Employees
        //        .Include(e => e.Department)
        //        .Select(e => new EmployeeDepartmentDto
        //        {
        //            EmployeeId = e.EmployeeID,
        //            FullName = $"{e.FirstName} {e.LastName}",
        //            DepartmentId = e.Department.DepartmentID,
        //            DepartmentName = e.Department.Name
        //        })
        //        .OrderBy(dto => dto.DepartmentName)
        //        .ThenBy(dto => dto.FullName)
        //        .ToListAsync();
        //}
    }
}
