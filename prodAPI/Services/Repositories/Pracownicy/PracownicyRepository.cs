using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;
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
        public async Task<IEnumerable<PracownicyDto>> GetPracownicyAsync()
        {
            return await _context.Pracownicies.ToListAsync();
        }

        public async Task AddPracownikAsync(PracownicyDto Pracownic)
        {
            _context.Pracownicies.Add(Pracownic);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeletePracownik(PracownicyDto Pracownic)
        {
            _context.Pracownicies.Remove(Pracownic);
        }


    }
}
