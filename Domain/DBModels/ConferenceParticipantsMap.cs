using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConferenceParticipantsMap
    {
        public int Id { get; set; }
        public int? ParticipantsId { get; set; }
        public int? ConferenceId { get; set; }
        public int? Active { get; set; }
    }
}
