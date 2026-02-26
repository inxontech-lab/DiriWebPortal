using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class AlbumMaster
    {
        public int Id { get; set; }
        public string? AlbumName { get; set; }
        public string? ThumbnailLocation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Active { get; set; }
    }
}
