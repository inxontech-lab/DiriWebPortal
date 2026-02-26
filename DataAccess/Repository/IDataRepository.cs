

using Domain.DBModels;
using Domain.RespDTO.PublicationsRespDTO;

namespace DataAccess.Repository
{
    public interface IDataRepository : IDisposable
    {
        Task<List<BookDetailsDTO>> GetBookDetails(int BookId);
    }
}
