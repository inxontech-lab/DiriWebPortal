using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class BookMaster
    {
        public int Id { get; set; }
        public int PublicationTypeId { get; set; }
        public string? BookNameEng { get; set; }
        public string? BookNameBn { get; set; }
        public string? WritterName { get; set; }
        public string? PublisherName { get; set; }
        public string? FirstPublishedYear { get; set; }
        public int? CurrentEditionNo { get; set; }
        public string? ThumbnailLocation { get; set; }
        public string? ShortDescription { get; set; }
        public int? Active { get; set; }
    }
}
