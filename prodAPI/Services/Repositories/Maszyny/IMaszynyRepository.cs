using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface IMaszynyRepository
    {
        Task<(IEnumerable<MaszynyDto>, PaginationMetadata)> GetMaszynyAsync(
            string? nazwa, string? marka, string? model, string? Kategoria,
            string? searchQuery, int pageNumber, int pageSize);
        Task<MaszynyDto?> GetMaszynyAsync(int idMaszyna);
        Task AddMaszynaAsync(MaszynyDto maszyna);

        void DeleteMaszyna(MaszynyDto maszyna);
        Task<bool> SaveChangesAsync();
    }
}
