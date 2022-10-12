using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface IStatusRepository
    {
        Task<(IEnumerable<StatusDto>, PaginationMetadata)> GetStatusAsync(
            int? idZlecenia, int? idPracownika, int? idEtapu, 
            bool? status, int pageNumber, int pageSize);
        Task<StatusDto?> GetStatusAsync(int idStatusu);
        Task AddStatusAsync(StatusDto status);

        void DeleteStatus(StatusDto status);
        Task<bool> SaveChangesAsync();
    }
}
