﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Domain.Entity
{
    public class WorkSchedule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan StartTime { get; set; }
    }
}
