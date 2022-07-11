using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;

namespace prodAPI.Services
{
    public interface IKontumRepository
    {
        Task<IEnumerable<KontumDto>> GetKontumAsync();
        Task<KontumDto?> GetKontumAsync(int idKontumu);
        Task AddKontoAsync(KontumDto Kontum);

        void DeleteKonto(KontumDto Kontum);
        Task<bool> SaveChangesAsync();
    }
}
