using Microsoft.EntityFrameworkCore;

using prodAPI.Models;

namespace prodAPI.Services
{
    public class PracownicyRepository : IPracownicyRepository
    {
        private production_dbContext _context;

        public PracownicyRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<PracownicyDto?> GetPracownicyAsync(int idPracownika)
        {
            return await _context.Pracownicies.Where(c=>c.IdPracownika==idPracownika).FirstOrDefaultAsync();
        }
        public async Task<(IEnumerable<PracownicyDto>, PaginationMetadata)> GetPracownicyAsync(
            string? imie, string? email, string? nrTel,
            string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _context.Pracownicies as IQueryable<PracownicyDto>;

            if (!string.IsNullOrWhiteSpace(imie))
            {
                imie = imie.Trim().ToLower();
                collection = collection.Where(c => c.Imie.ToLower() == imie);
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                email = email.Trim().ToLower();
                collection = collection.Where(c => c.Email.ToLower() == email);
            }

            if (!string.IsNullOrWhiteSpace(nrTel))
            {
                nrTel = nrTel.Trim().ToLower();
                collection = collection.Where(c => c.Nrtel.ToLower() == nrTel);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim().ToLower();
                collection = collection
                    .Where(q => q.Imie.Contains(searchQuery.ToLower())
                    || (q.Email.Contains(searchQuery.ToLower()))
                    || (q.Nrtel.Contains(searchQuery.ToLower()))
                    || (q.Nazwisko.Contains(searchQuery.ToLower())));
            }

            var totalItemCount = await collection.CountAsync();
            var paginationMetadata = new PaginationMetadata(
                totalItemCount, pageSize, pageNumber);

            var retCol = await collection
                .OrderBy(c => c.IdPracownika)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();

            return (retCol, paginationMetadata);
        }

        public async Task AddPracownikAsync(PracownicyDto pracownik)
        {
            _context.Pracownicies.Add(pracownik);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeletePracownik(PracownicyDto pracownik)
        {
            _context.Pracownicies.Remove(pracownik);
        }


    }
}
