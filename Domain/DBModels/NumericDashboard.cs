using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class NumericDashboard
    {
        public int Id { get; set; }
        public int? TotalJournal { get; set; }
        public int? ResearchTittle { get; set; }
        public int? UniversityInvolved { get; set; }
        public int? Conference { get; set; }
        public int? Active { get; set; }
    }
}
