using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class AboutU
    {
        public int Id { get; set; }
        public string? AboutUsTitle { get; set; }
        public string? AbouUsText { get; set; }
        public int? Active { get; set; }
    }
}
