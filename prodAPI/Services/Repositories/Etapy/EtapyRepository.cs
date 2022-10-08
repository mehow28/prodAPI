using Microsoft.EntityFrameworkCore;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class EtapyRepository : IEtapyRepository
    {
        private production_dbContext _context;

        public EtapyRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<EtapyDto?> GetEtapAsync(int idEtapu)
        {
            return await _context.Etapies.Where(c => c.IdEtapu == idEtapu).FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<EtapyDto>, PaginationMetadata)> GetEtapyAsync(
            string? nazwa, string? searchQuery,
            int pageNumber, int pageSize)
        {
            var collection = _context.Etapies as IQueryable<EtapyDto>;

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
                .OrderBy(c => c.IdEtapu)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);

        }

        public async Task AddEtapAsync(EtapyDto etap)
        {
            _context.Etapies.Add(etap);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteEtap(EtapyDto etap)
        {
            _context.Etapies.Remove(etap);
        }
    }
}
