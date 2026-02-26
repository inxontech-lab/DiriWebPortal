using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ArchivesAndDocumentation
    {
        public int Id { get; set; }
        public int? DocumentTypeId { get; set; }
        public string? DocumentTittle1 { get; set; }
        public string? DocumentTittle2 { get; set; }
        public string? DocumentTittle3 { get; set; }
        public string? DocumentDescription { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
