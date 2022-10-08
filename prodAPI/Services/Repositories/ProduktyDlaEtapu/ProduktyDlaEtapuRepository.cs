using Microsoft.EntityFrameworkCore;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class ProduktyDlaEtapuRepository : IProduktyDlaEtapuRepository
    {
        private production_dbContext _context;

        public ProduktyDlaEtapuRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ProduktyDlaEtapuDto?> GetProduktDlaEtapuAsync(int id)
        {
            return await _context.ProduktyDlaEtapus.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<ProduktyDlaEtapuDto>, PaginationMetadata)> GetProduktyDlaEtapuAsync(
            int? idEtapu, int? idProduktu,
            int pageNumber, int pageSize)
        {
            var collection = _context.ProduktyDlaEtapus as IQueryable<ProduktyDlaEtapuDto>;

            if (idEtapu!=null)
            {
                collection = collection.Where(c => c.IdEtapu==idEtapu);
            }

            if (idProduktu != null)
            {
                collection = collection.Where(c => c.IdProduktu == idProduktu);
            }

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collection
                .OrderBy(c => c.Id)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);

        }

        public async Task AddProduktyDlaEtapuAsync(ProduktyDlaEtapuDto pde)
        {
            _context.ProduktyDlaEtapus.Add(pde);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteProduktyDlaEtapu(ProduktyDlaEtapuDto pde)
        {
            _context.ProduktyDlaEtapus.Remove(pde);
        }
    }
}
