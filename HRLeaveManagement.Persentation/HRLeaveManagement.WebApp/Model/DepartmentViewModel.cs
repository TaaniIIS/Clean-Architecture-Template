using System.Text.Json.Serialization;

namespace HRLeaveManagement.WebApp.Model
{
    public class DepartmentViewModel
    {
        //public int Departmentid { get; set; }
        //public string Name { get; set; }

        public int Departmentid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }
    }
}
