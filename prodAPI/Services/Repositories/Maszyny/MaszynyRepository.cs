using Microsoft.EntityFrameworkCore;

using prodAPI.Models;

namespace prodAPI.Services
{
    public class AuthenticationRepository : IMaszynyRepository
    {
        private production_dbContext _context;

        public AuthenticationRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<MaszynyDto?> GetMaszynyAsync(int idMaszyny)
        {
            return await _context.Maszynies.Where(c=>c.IdMaszyny==idMaszyny).FirstOrDefaultAsync();
        }
        public async Task<(IEnumerable<MaszynyDto>,PaginationMetadata)> GetMaszynyAsync(
            string? nazwa, string? marka, string? model, string? kategoria,
            string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Maszynies as IQueryable<MaszynyDto>;

            if (!string.IsNullOrWhiteSpace(nazwa))
            {
                nazwa = nazwa.Trim().ToLower();
                collection = collection.Where(c => c.Nazwa.ToLower() == nazwa);
            }

            if (!string.IsNullOrWhiteSpace(model))
            {
                model = model.Trim().ToLower();
                collection = collection.Where(c => c.Model.ToLower() == model);
            }

            if (!string.IsNullOrWhiteSpace(marka))
            {
                marka = marka.Trim().ToLower();
                collection = collection.Where(c => c.Marka.ToLower() == marka);
            }
            if (!string.IsNullOrWhiteSpace(kategoria))
            {
                kategoria = kategoria.Trim().ToLower();
                collection = collection.Where(c => c.Kategoria.ToLower() == kategoria);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
                {
                searchQuery = searchQuery.Trim().ToLower();
                collection = collection
                    .Where(q => q.Nazwa.Contains(searchQuery.ToLower())
                    || (q.Marka.Contains(searchQuery.ToLower()))
                    || (q.Model.Contains(searchQuery.ToLower())));
            }

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collection
                .OrderBy(c => c.IdMaszyny)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
        }

        public async Task AddMaszynaAsync(MaszynyDto maszyna)
        {
           await _context.Maszynies.AddAsync(maszyna);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteMaszyna(MaszynyDto maszyna)
        {
            _context.Maszynies.Remove(maszyna);
        }


    }
}
