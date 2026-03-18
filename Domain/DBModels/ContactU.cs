using System;
using System.Collections.Generic;

namespace Domain.DBModels
{
    public partial class ContactU
    {
        public int Id { get; set; }
        public string? OrganizationTittle { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Address3 { get; set; }
        public string? Address4 { get; set; }
        public string? Division { get; set; }
        public string? District { get; set; }
        public string? PoliceStation { get; set; }
        public string? PostOffice { get; set; }
        public string? PostCode { get; set; }
        public string? Email1 { get; set; }
        public string? Email2 { get; set; }
        public string? Mobile1 { get; set; }
        public string? Mobile2 { get; set; }
        public string? LocationMap1 { get; set; }
        public string? LocationMap2 { get; set; }
        public string? LocationMap3 { get; set; }
        public string? LocationMap4 { get; set; }
        public string? LogoLocation { get; set; }
        public string? TwitterLink { get; set; }
        public string? FacebookLink { get; set; }
        public string? InstagramLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? YoutubeLink { get; set; }
        public int? Active { get; set; }
    }
}
