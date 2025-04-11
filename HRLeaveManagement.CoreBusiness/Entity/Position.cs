using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Web.Domain.Entity
{
    public class Position
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int PositionID { get; set; }
        public string? Title { get; set; }
        public string? JobLevel { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Employee>? Employees { get; set; }

       
    }

}
