namespace HRLeaveManagement.WebApp.Model
{
    public class LeaveRequestViewModel
    {
        public int LeaveRequestID { get; set; }
        
        public string FullName { get; set; }
        public string LeaveTypeName { get; set; }
        public string EmployeeName { get; set; }
        public string PositionName { get; set; }

        public string shift { get; set; }
        public int phone { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "Pending"; // Default status
        public string Description { get; set; }
        public int LeaveAmount { get; set; }

        // Foreign Keys
        public int EmployeeID { get; set; }
        public int LeaveTypeID { get; set; }
    }
}
