using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ExecutiveCommitteeDesignation
    {
        public int Id { get; set; }
        public string? Designation { get; set; }
        public int? Seniority { get; set; }
        public int? Active { get; set; }
    }
}
