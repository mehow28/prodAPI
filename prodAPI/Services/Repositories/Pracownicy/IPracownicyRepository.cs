using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;

namespace prodAPI.Services
{
    public interface IPracownicyRepository
    {
        Task<IEnumerable<PracownicyDto>> GetPracownicyAsync();
        Task<PracownicyDto?> GetPracownicyAsync(int idPracowniku);
        Task AddPracownikAsync(PracownicyDto Pracownik);

        void DeletePracownik(PracownicyDto Pracownik);
        Task<bool> SaveChangesAsync();
    }
}
