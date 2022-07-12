using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;

namespace prodAPI.Services
{
    public interface IPracownicyRepository
    {
        Task<IEnumerable<PracownicyDto>> GetPracownicyAsync();
        Task<PracownicyDto?> GetPracownicyAsync(int idPracowniku);
        Task AddPracownikAsync(PracownicyDto pracownik);

        void DeletePracownik(PracownicyDto pracownik);
        Task<bool> SaveChangesAsync();
    }
}
