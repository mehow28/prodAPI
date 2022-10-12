using Microsoft.EntityFrameworkCore;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class SurowceDlaEtapuRepository : ISurowceDlaEtapuRepository
    {
        private production_dbContext _context;

        public SurowceDlaEtapuRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<SurowceDlaEtapuDto?> GetSurowiecDlaEtapuAsync(int id)
        {
            return await _context.SurowceDlaEtapus.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<SurowceDlaEtapuDto>, PaginationMetadata)> GetSurowceDlaEtapuAsync(
            int? idEtapu, int? idSurowca,
            int pageNumber, int pageSize)
        {
            var collection = _context.SurowceDlaEtapus as IQueryable<SurowceDlaEtapuDto>;

            if (idEtapu!=null)
            {
                collection = collection.Where(c => c.IdEtapu==idEtapu);
            }

            if (idSurowca != null)
            {
                collection = collection.Where(c => c.IdSurowca == idSurowca);
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

        public async Task AddSurowceDlaEtapuAsync(SurowceDlaEtapuDto pde)
        {
            _context.SurowceDlaEtapus.Add(pde);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteSurowceDlaEtapu(SurowceDlaEtapuDto pde)
        {
            _context.SurowceDlaEtapus.Remove(pde);
        }
    }
}
