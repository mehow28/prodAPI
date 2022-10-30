using prodAPI.Models;

namespace prodAPI.Services
{ 
    public interface IHelperRepository
    {
        Task<(IEnumerable<ZleceniumDto>, PaginationMetadata)> GetZleceniaByPracownikAsync(
            int idPracownika);
        Task<bool> SaveChangesAsync();
    }
}
