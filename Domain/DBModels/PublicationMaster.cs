using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class PublicationMaster
    {
        public int Id { get; set; }
        public int PublicationTypeId { get; set; }
        public string? PublicationTopic { get; set; }
        public string? Tittle1 { get; set; }
        public string? Tittle2 { get; set; }
        public string? PublicationThumbnail { get; set; }
        public string? FileLocation { get; set; }
        public string? Publisher { get; set; }
        public string? PublishedYear { get; set; }
        public int? ConferenceId { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
