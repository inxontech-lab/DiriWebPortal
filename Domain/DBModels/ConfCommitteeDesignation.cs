using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConfCommitteeDesignation
    {
        public int Id { get; set; }
        public string? CommitteeDesignation { get; set; }
        public int? Seniority { get; set; }
        public int? Active { get; set; }
    }
}
