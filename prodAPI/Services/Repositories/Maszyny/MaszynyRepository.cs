using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class MaszynyRepository : IMaszynyRepository
    {
        private production_dbContext _context;

        public MaszynyRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<MaszynyDto?> GetMaszynyAsync(int idMaszyny)
        {
            return await _context.Maszynies.Where(c=>c.IdMaszyny==idMaszyny).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<MaszynyDto>> GetMaszynyAsync()
        {
            return await _context.Maszynies.ToListAsync();
        }

        public async Task AddMaszynaAsync(MaszynyDto maszyna)
        {
            _context.Maszynies.Add(maszyna);
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
