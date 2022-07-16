using Microsoft.EntityFrameworkCore;

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

        public async Task<(IEnumerable<ProduktyDto>, PaginationMetadata)> GetProduktyAsync(
            string? nazwa, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Produkties as IQueryable<ProduktyDto>;
            
            if (!string.IsNullOrWhiteSpace(nazwa))
            {
                nazwa = nazwa.Trim().ToLower();
                collection = collection.Where(c => c.Nazwa.ToLower() == nazwa);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim().ToLower();
                collection = collection.Where(q => q.Nazwa.Contains(searchQuery.ToLower()));
            }

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collection
                .OrderBy(c=>c.IdProduktu)
                .Skip(pageSize*(pageNumber-1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
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
