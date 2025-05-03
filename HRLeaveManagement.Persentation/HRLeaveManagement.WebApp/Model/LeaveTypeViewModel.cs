using System.ComponentModel.DataAnnotations;

namespace HRLeaveManagement.WebApp.Model
{
    public class LeaveTypeViewModel
    {
        public int LeaveTypeID { get; set; } 

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; } = string.Empty; // "Vacation", "Sick", etc.

        [Required(ErrorMessage = "Default days is required")]
        [Range(1, 365, ErrorMessage = "Default days must be between 1 and 365")]
        public int DefaultDays { get; set; } // 10, 15, etc.
    }
}
