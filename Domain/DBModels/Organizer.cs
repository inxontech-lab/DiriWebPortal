using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Organizer
    {
        public int Id { get; set; }
        public int ConferenceId { get; set; }
        public int OrganizerId { get; set; }
        public int? Active { get; set; }
    }
}
