using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Nationality
    {
        public string NationalityId { get; set; } = null!;
        public string NationalityDescription { get; set; } = null!;
        public string? NationalityArabic { get; set; }
        public int Active { get; set; }
    }
}
