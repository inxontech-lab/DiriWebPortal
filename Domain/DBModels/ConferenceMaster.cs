using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ConferenceMaster
    {
        public int Id { get; set; }
        public int? ConferenceYear { get; set; }
        public DateTime? ConfrenceFromDate { get; set; }
        public DateTime? ConferenceTodate { get; set; }
        public int? MainThemeId { get; set; }
        public string? ConferenceTitle { get; set; }
        public string? Subtitle { get; set; }
        public string? ConferenceCode { get; set; }
        public string? ShortDescription { get; set; }
        public int? Platform { get; set; }
        public string? Venue { get; set; }
        public string? VanueLocation { get; set; }
        public string? OrganizedBy1 { get; set; }
        public string? OrganizedBy2 { get; set; }
        public string? OrganizedBy3 { get; set; }
        public string? BannerImagePath { get; set; }
        public string? HeroImagePath { get; set; }
        public int? IsAcceptingProposal { get; set; }
        public string? CallForPaperPath { get; set; }
        public string? ConferenceScheduleFilePath { get; set; }
        public int? HighlightSwitch { get; set; }
        public int? Active { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifedDate { get; set; }
    }
}
