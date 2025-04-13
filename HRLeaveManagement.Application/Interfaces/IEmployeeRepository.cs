using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRLeaveManagement.CoreBusiness.Entity;

namespace HRLeaveManagement.Application.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
       public Task<List<Employee>> GetEmployeeByDepartment();
    }
}
