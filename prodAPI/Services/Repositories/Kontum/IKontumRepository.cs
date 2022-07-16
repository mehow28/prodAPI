using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface IKontumRepository
    {
        Task<IEnumerable<KontumDto>> GetKontumAsync();
        Task<KontumDto?> GetKontumAsync(int idKontumu);
        Task AddKontoAsync(KontumDto konto);

        void DeleteKonto(KontumDto konto);
        Task<bool> SaveChangesAsync();
        string getHash(string text);
    }
}
