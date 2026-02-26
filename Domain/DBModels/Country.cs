using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class Country
    {
        public int Id { get; set; }
        public string? CountryName { get; set; }
        public string? CountryCode { get; set; }
        public int? Active { get; set; }
    }
}
