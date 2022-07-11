using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;

namespace prodAPI.Services
{
    public interface IMaszynyRepository
    {
        Task<IEnumerable<MaszynyDto>> GetMaszynyAsync();
        Task<MaszynyDto?> GetMaszynyAsync(int idMaszyna);
        Task AddMaszynaAsync(MaszynyDto maszyna);

        void DeleteMaszyna(MaszynyDto maszyna);
        Task<bool> SaveChangesAsync();
    }
}
