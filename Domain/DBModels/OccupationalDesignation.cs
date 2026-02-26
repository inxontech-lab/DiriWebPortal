using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class OccupationalDesignation
    {
        public int Id { get; set; }
        public string? OccupationalDesignationName { get; set; }
        public int? Active { get; set; }
    }
}
