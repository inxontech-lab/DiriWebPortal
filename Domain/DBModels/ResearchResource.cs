using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ResearchResource
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public int ParticipantId { get; set; }
        public string? ResearchTitle { get; set; }
        public string? Keywords { get; set; }
        public string? ResourcePath { get; set; }
        public int? Active { get; set; }
    }
}
