using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class HomePage
    {
        public int Id { get; set; }
        public string? PageTittle1 { get; set; }
        public string? PageTittle2 { get; set; }
        public string? PageTittle3 { get; set; }
        public string? PageDescription { get; set; }
        public string? Banner1 { get; set; }
        public string? Banner2 { get; set; }
        public string? Banner3 { get; set; }
        public int Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
