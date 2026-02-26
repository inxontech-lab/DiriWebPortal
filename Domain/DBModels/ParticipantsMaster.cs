using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ParticipantsMaster
    {
        public int Id { get; set; }
        public int? UniversityId { get; set; }
        public string? ParticipantName { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? EducationalQualification { get; set; }
        public string? Occupation { get; set; }
        public string? ImagePath { get; set; }
        public int Active { get; set; }
    }
}
