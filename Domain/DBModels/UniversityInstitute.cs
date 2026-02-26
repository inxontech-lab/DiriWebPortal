using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class UniversityInstitute
    {
        public int Id { get; set; }
        public string? UniversityName { get; set; }
        public int? CountryId { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? Website { get; set; }
        public int? Active { get; set; }
    }
}
