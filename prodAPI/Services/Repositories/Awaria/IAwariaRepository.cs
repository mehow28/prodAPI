using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface IAwariaRepository
    {

        Task<IEnumerable<AwariaDto>> GetAwariaAsync();
        Task<(IEnumerable<AwariaDto>, PaginationMetadata)> GetAwariaAsync(
            DateTime? dataZgloszenia, int pageNumber, int pageSize);
        Task<AwariaDto?> GetAwariaAsync(int idAwariau);
        Task AddAwariaAsync(AwariaDto produkt);

        void DeleteAwaria(AwariaDto produkt);
        Task<bool> SaveChangesAsync();
    }
}
