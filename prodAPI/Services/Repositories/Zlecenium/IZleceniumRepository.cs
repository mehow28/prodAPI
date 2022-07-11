using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;

namespace prodAPI.Services
{
    public interface IZleceniumRepository
    {
        Task<IEnumerable<ZleceniumDto>> GetZleceniumAsync();
        Task<ZleceniumDto?> GetZleceniumAsync(int idZleceniumu);
        Task AddZleceniumAsync(ZleceniumDto Zlecenium);

        void DeleteZlecenium(ZleceniumDto Zlecenium);
        Task<bool> SaveChangesAsync();
    }
}
