using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface IZleceniumRepository
    {
        Task<(IEnumerable<ZleceniumDto>, PaginationMetadata)> GetZleceniumAsync(
            DateTime? dataRozpoczecia, DateTime? dataZakonczenia, 
            int pageNumber, int pageSize);
        Task<ZleceniumDto?> GetZleceniumAsync(int idZleceniumu);
        Task AddZleceniumAsync(ZleceniumDto Zlecenium);

        void DeleteZlecenium(ZleceniumDto Zlecenium);
        Task<bool> SaveChangesAsync();
    }
}
