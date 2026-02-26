using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class AlbumPhoto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string? PhotoLocation { get; set; }
        public int? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
