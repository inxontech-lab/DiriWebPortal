using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ManagingTrusteeDesignation
    {
        public int Id { get; set; }
        public string? DesignationDetails { get; set; }
        public int? Active { get; set; }
    }
}
