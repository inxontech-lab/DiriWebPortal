using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class OrganizerMaster
    {
        public int Id { get; set; }
        public string OrganizerNameEn { get; set; } = null!;
        public string? OrganizerNameBn { get; set; }
        public string? OrganizerNameAr { get; set; }
        public string? AddressEn { get; set; }
        public string? AddressBn { get; set; }
        public string? AddressAr { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? Logo { get; set; }
        public int Active { get; set; }
    }
}
