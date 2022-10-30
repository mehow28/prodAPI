using Microsoft.EntityFrameworkCore;

using prodAPI.Models;

namespace prodAPI.Services
{
    public class HelperRepository : IHelperRepository
    {
        private production_dbContext _context;

        public HelperRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<(IEnumerable<ZleceniumDto>, PaginationMetadata)> GetZleceniaByPracownikAsync(
            int idPracownika)
        {
            int pageNumber = 1;
            int pageSize = 20;
            Console.WriteLine("idPracownika: ", idPracownika);
            var collectionStatuses = _context.Statuses as IQueryable<StatusDto>;
            var collectionZlecenia = _context.Zlecenia as IQueryable<ZleceniumDto>;

            collectionStatuses = collectionStatuses.Where(c => c.IdPracownika == idPracownika);
            List<int> ids = new List<int>();
            
            foreach(var col in collectionStatuses)
            {
                Console.WriteLine(col.IdZlecenia);
                ids.Add(col.IdZlecenia);
            }
            collectionZlecenia = collectionZlecenia.Where(c=>ids.Contains(c.IdZlecenia));
          
            var totalItemCount = await collectionZlecenia.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collectionZlecenia
                .OrderBy(c => c.IdZlecenia)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
