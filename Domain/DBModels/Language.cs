using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Language
    {
        public int Id { get; set; }
        public int? ConferenceId { get; set; }
        public int? LanguageId { get; set; }
        public int? Active { get; set; }
    }
}
