using Domain.DTO.JournalSchemaDTO;
using Domain.RespDTO.JournalSchemaRespDTO;

namespace DiriJournal.Services
{
    public class JounalService
    {
        private ServiceClient serviceClient { get; set; } = new();
        private JournalMasterRespDTO? _JournalMasterRespDTO;
        private List<JournalVolumeDTO>? _lstJournal;
        private JournalDetailsRespDTO _JournalDetailsRespDTO;
        private JournalDTO _JournalDTO;
    }
}
