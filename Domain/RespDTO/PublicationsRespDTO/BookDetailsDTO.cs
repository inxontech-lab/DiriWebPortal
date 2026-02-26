using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RespDTO.PublicationsRespDTO
{
    public class BookDetailsDTO
    {
        public int Id { get; set; }
        public int PublicationTypeId { get; set; }
        public string? BookNameEng { get; set; }
        public string? BookNameBn { get; set; }
        public string? WritterName { get; set; }
        public string? PublisherName { get; set; }
        public string? FirstPublishedYear { get; set; }
        public string? ThumbnailLocation { get; set; }
        public string? ShortDescription { get; set; }
        public int? AttachmentId { get; set; }
        public string? AttachmentLocation { get; set; }
        public string? AttachmentTittle { get; set; }
        public int? AttachmentSerial { get; set; }
    }
}
