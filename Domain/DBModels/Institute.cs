using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Institute
    {
        public Institute()
        {
            Journals = new HashSet<Journal>();
        }

        public int InstituteId { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<Journal> Journals { get; set; }
    }
}
