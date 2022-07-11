using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;

namespace prodAPI.Services
{
    public interface IProduktyRepository
    {
        Task<IEnumerable<ProduktyDto>> GetProduktyAsync();
        Task<ProduktyDto?> GetProduktyAsync(int idProduktu);
        Task AddProduktAsync(ProduktyDto produkt);

        void DeleteProdukt(ProduktyDto produkt);
        Task<bool> SaveChangesAsync();
    }
}
