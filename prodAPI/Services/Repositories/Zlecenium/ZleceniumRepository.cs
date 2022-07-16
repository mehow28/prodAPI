using Microsoft.EntityFrameworkCore;

using prodAPI.Models;

namespace prodAPI.Services
{
    public class ZleceniumRepository : IZleceniumRepository
    {
        private production_dbContext _context;

        public ZleceniumRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ZleceniumDto?> GetZleceniumAsync(int idZlecenia)
        {
            return await _context.Zlecenia.Where(c=>c.IdZlecenia==idZlecenia).FirstOrDefaultAsync();
        }
        public async Task<(IEnumerable<ZleceniumDto>,PaginationMetadata)> GetZleceniumAsync(
            DateTime? data, int? idProduktu,
            int pageNumber, int pageSize)
        {
            var collection = _context.Zlecenia as IQueryable<ZleceniumDto>;

            if (data is not null)
                collection = collection.Where(c => c.Data>data);

            if (idProduktu is not null)
                collection = collection.Where(c => c.IdProduktu == idProduktu);

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collection
                .OrderBy(c => c.IdZlecenia)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
        }

        public async Task AddZleceniumAsync(ZleceniumDto zlecenium)
        {
            _context.Zlecenia.Add(zlecenium);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteZlecenium(ZleceniumDto zlecenium)
        {
            _context.Zlecenia.Remove(zlecenium);
        }


    }
}
