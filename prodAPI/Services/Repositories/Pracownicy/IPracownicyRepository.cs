using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface IPracownicyRepository
    {
        Task<(IEnumerable<PracownicyDto>,PaginationMetadata)> GetPracownicyAsync(
            string? imie, string? email, string? nrTel, 
            string? searchQuery, int pageNumber, int pageSize);
        Task<PracownicyDto?> GetPracownicyAsync(int idPracowniku);
        Task AddPracownikAsync(PracownicyDto pracownik);

        void DeletePracownik(PracownicyDto pracownik);
        Task<bool> SaveChangesAsync();
    }
}
