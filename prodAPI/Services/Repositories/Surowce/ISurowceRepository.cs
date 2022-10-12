using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface ISurowceRepository
    {

        Task<IEnumerable<SurowceDto>> GetSurowceAsync();
        Task<(IEnumerable<SurowceDto>, PaginationMetadata)> GetSurowceAsync(
            string? nazwa, string? searchQuery, int pageNumber, int pageSize);
        Task<SurowceDto?> GetSurowceAsync(int idSurowca);
        Task AddSurowiecAsync(SurowceDto surowiec);

        void DeleteSurowiec(SurowceDto surowiec);
        Task<bool> SaveChangesAsync();
    }
}
