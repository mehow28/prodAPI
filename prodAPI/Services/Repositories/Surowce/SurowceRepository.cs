using Microsoft.EntityFrameworkCore;

using prodAPI.Models;

namespace prodAPI.Services
{
    public class SurowceRepository : ISurowceRepository
    {
        private production_dbContext _context;

        public SurowceRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<SurowceDto?> GetSurowceAsync(int idSurowca)
        {
            return await _context.Surowcies.Where(c=>c.IdSurowca==idSurowca).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SurowceDto>> GetSurowceAsync()
        {
            return await _context.Surowcies.ToListAsync();
        }

        public async Task<(IEnumerable<SurowceDto>, PaginationMetadata)> GetSurowceAsync(
            string? nazwa, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Surowcies as IQueryable<SurowceDto>;
            
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
                .OrderBy(c=>c.IdSurowca)
                .Skip(pageSize*(pageNumber-1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
        }

        public async Task AddSurowiecAsync(SurowceDto Surowiec)
        {
            _context.Surowcies.Add(Surowiec);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteSurowiec(SurowceDto Surowiec)
        {
            _context.Surowcies.Remove(Surowiec);
        }


    }
}
