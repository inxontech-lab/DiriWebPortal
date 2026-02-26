using Domain.DTO.ConferenceSchemaDTO;
using Domain.DTO.PublicationShemaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IDiriContextDataRepo : IDisposable
    {
        Task<List<ConferenceDetailsDTO>> GetUpcomingConferenceDetails();
        Task<List<PublicationsArticlesDTO>> GetPublicationArticleList();
    }
}
