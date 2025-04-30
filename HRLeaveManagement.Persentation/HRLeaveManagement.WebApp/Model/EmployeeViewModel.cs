namespace HRLeaveManagement.WebApp.Model
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string JobLevel { get; set; }

        public string Shift { get; set; }
        public int Phone { get; set; }
        public int PositionID { get; set; }
        public int DepartmentID { get; set; }
       // public int LeaveTypeID { get; set; }
    }
}
