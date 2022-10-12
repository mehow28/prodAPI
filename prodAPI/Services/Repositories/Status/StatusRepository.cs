using Microsoft.EntityFrameworkCore;

using prodAPI.Models;

namespace prodAPI.Services
{
    public class StatusRepository : IStatusRepository
    {
        private production_dbContext _context;

        public StatusRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<StatusDto?> GetStatusAsync(int idStatusu)
        {
            return await _context.Statuses.Where(c=>c.IdStatusu==idStatusu).FirstOrDefaultAsync();
        }
        public async Task<(IEnumerable<StatusDto>, PaginationMetadata)> GetStatusAsync(
            int? idZlecenia, int? idPracownika, int? idEtapu,
            bool? status, int pageNumber, int pageSize)
        {
            var collection = _context.Statuses as IQueryable<StatusDto>;

            if (idZlecenia is not null)
                collection = collection.Where(c => c.IdZlecenia == idZlecenia);

            if (idPracownika is not null)
                collection = collection.Where(c => c.IdPracownika == idPracownika);

            if (idEtapu is not null)
                collection = collection.Where(c => c.IdEtapu == idEtapu);

            if (status is not null)
                collection = collection.Where(c => c.Stan == status);

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collection
                .OrderBy(c => c.IdStatusu)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
        }

        public async Task AddStatusAsync(StatusDto status)
        {
            _context.Statuses.Add(status);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteStatus(StatusDto status)
        {
            _context.Statuses.Remove(status);
        }


    }
}
