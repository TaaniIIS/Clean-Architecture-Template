using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HRLeaveManagement.CoreBusiness.Entity.EmploymentType;

namespace HRLeaveManagement.CoreBusiness.Entity
{
    public class EmploymentType
    {
        
        public int EmploymentTypeID { get; set; }
        public string Name { get; set; } // Full-time, Part-time, etc.
                                         // Navigation Property
        public ICollection<Employee> Employees { get; set; }

        public enum EmploymentTypeEnum
        {
            [Display(Name = "Full-time Employment")]
            FullTime = 1,
            [Display(Name = "Part-time Employment")]
            PartTime = 2,
            [Display(Name = "Contractor Employment")]
            Contractor = 3
            // Add others if needed
        }


        // Enum property (not mapped to database)

        [NotMapped]
        public EmploymentTypeEnum Type
        {
            get => Name switch
            {
                "Full-time" => EmploymentTypeEnum.FullTime,
                "Part-time" => EmploymentTypeEnum.PartTime,
                "Contractor" => EmploymentTypeEnum.Contractor,
                _ => EmploymentTypeEnum.FullTime // Default fallback
            };
            set => Name = value.ToString();
        }
    }
}
