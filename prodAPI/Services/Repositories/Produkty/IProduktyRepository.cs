using prodAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace prodAPI.Services
{
    public interface IProduktyRepository
    {

        Task<IEnumerable<ProduktyDto>> GetProduktyAsync();
        Task<(IEnumerable<ProduktyDto>, PaginationMetadata)> GetProduktyAsync(
            string? nazwa, string? searchQuery, int pageNumber, int pageSize);
        Task<ProduktyDto?> GetProduktyAsync(int idProduktu);
        Task AddProduktAsync(ProduktyDto produkt);

        void DeleteProdukt(ProduktyDto produkt);
        Task<bool> SaveChangesAsync();
    }
}
