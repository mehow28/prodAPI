using prodAPI.Models;

namespace prodAPI.Services
{
    public interface IEtapyRepository
    {
        Task<(IEnumerable<EtapyDto>,PaginationMetadata)> GetEtapyAsync(
            string? nazwa, string? searchQuery, 
            int pageNumber, int pageSize);
        Task<EtapyDto?> GetEtapAsync(int idEtapu);
        Task AddEtapAsync(EtapyDto etap);

        void DeleteEtap(EtapyDto etap);
        Task<bool> SaveChangesAsync();
    }
}
