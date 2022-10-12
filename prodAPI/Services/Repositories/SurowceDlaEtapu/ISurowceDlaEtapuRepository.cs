using prodAPI.Models;

namespace prodAPI.Services
{
    public interface ISurowceDlaEtapuRepository
    {
        Task<(IEnumerable<SurowceDlaEtapuDto>,PaginationMetadata)> GetSurowceDlaEtapuAsync(
            int? idEtapu, int? idSurowca,
            int pageNumber, int pageSize);
        Task<SurowceDlaEtapuDto?> GetSurowiecDlaEtapuAsync(int id);
        Task AddSurowceDlaEtapuAsync(SurowceDlaEtapuDto pde);

        void DeleteSurowceDlaEtapu(SurowceDlaEtapuDto pde);
        Task<bool> SaveChangesAsync();
    }
}
