using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Department
    {
        public int Id { get; set; }
        public string? DepartmentName { get; set; }
        public int? Active { get; set; }
    }
}
