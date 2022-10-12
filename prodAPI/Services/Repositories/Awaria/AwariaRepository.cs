using Microsoft.EntityFrameworkCore;

using prodAPI.Models;

namespace prodAPI.Services
{
    public class AwariaRepository : IAwariaRepository
    {
        private production_dbContext _context;

        public AwariaRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<AwariaDto?> GetAwariaAsync(int idAwarii)
        {
            return await _context.Awarias.Where(c=>c.IdAwarii==idAwarii).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AwariaDto>> GetAwariaAsync()
        {
            return await _context.Awarias.ToListAsync();
        }

        public async Task<(IEnumerable<AwariaDto>, PaginationMetadata)> GetAwariaAsync(
            DateTime? dataZgloszenia, int pageNumber, int pageSize)
        {
            var collection = _context.Awarias as IQueryable<AwariaDto>;

            if (dataZgloszenia is not null)
                collection = collection.Where(c => c.DataZgloszenia > dataZgloszenia);

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collection
                .OrderBy(c=>c.IdAwarii)
                .Skip(pageSize*(pageNumber-1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
        }

        public async Task AddAwariaAsync(AwariaDto awaria)
        {
            _context.Awarias.Add(awaria);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteAwaria(AwariaDto awaria)
        {
            _context.Awarias.Remove(awaria);
        }


    }
}
