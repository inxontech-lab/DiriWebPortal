using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.ConferenceSchemaDTO
{
    public class ConferenceDetailsDTO
    {
        public int Id { get; set; }
        public string? ConferenceTitle { get; set; }
        public string? Subtitle { get; set; }
        public string? ConferenceCode { get; set; }
        public string? ShortDescription { get; set; }
        public DateTime? ConfrenceFromDate { get; set; }
        public DateTime? ConferenceTodate { get; set; }
        public int? MainThemeId { get; set; }
        public string? Venue { get; set; }
        public string? VanueLocation { get; set; }
        public string? OrganizedBy1 { get; set; }
        public string? OrganizedBy2 { get; set; }
        public string? OrganizedBy3 { get; set; }
        public string? BannerImagePath { get; set; }
        public string? HeroImagePath { get; set; }
        public string? CallForPaperPath { get; set; }
        public string? ConferenceScheduleFilePath { get; set; }

        public string? MainTheme { get; set; }
        public List<string>? SubThemes { get; set; }
        public List<ImportantDateDTO>? ImportantDates { get; set; }
        public List<string>? Languages { get; set; }
        public List<InstructionDTO>? Instructions { get; set; }
        public List<OrganizerDTO> Organizers { get; set; }
    }

    public class ImportantDateDTO
    {
        public string? ActionDescription { get; set; }
        public DateTime? ActionDate { get; set; }
    }

    public class InstructionDTO
    {
        public string? InstructionTitle { get; set; }
        public List<string>? Details { get; set; }
    }

    public class OrganizerDTO
    {
        public string OrganizerNameEn { get; set; }
        public string OrganizerNameBn { get; set; }
        public string OrganizerNameAr { get; set; }
        public string AddressEn { get; set; }
        public string AddressBn { get; set; }
        public string AddressAr { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
    }
}
