using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class ProduktyRepository : IProduktyRepository
    {
        private production_dbContext _context;

        public ProduktyRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ProduktyDto?> GetProduktyAsync(int idProduktu)
        {
            return await _context.Produkties.Where(c=>c.IdProduktu==idProduktu).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ProduktyDto>> GetProduktyAsync()
        {
            return await _context.Produkties.ToListAsync();
        }

        public async Task AddProduktAsync(ProduktyDto produkt)
        {
            _context.Produkties.Add(produkt);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteProdukt(ProduktyDto produkt)
        {
            _context.Produkties.Remove(produkt);
        }


    }
}
