namespace HRLeaveManagement.WebApp.Model
{
    public class LeaveTypeViewModel
    {
        public int LeaveTypeID { get; set; } // 1, 2, 3, etc.
        public string Name { get; set; } // "Vacation", "Sick", etc.

        public int DefaultDays { get; set; } // 10, 15, etc.
    }
}
