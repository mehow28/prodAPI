using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class KontumRepository : IKontumRepository
    {
        private production_dbContext _context;

        public KontumRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<KontumDto?> GetKontumAsync(int IdKonta)
        {
            return await _context.Konties.Where(c=>c.IdKonta==IdKonta).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<KontumDto>> GetKontumAsync()
        {
            return await _context.Konties.ToListAsync();
        }

        public async Task AddKontoAsync(KontumDto Konto)
        {
            _context.Konties.Add(Konto);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteKonto(KontumDto Konto)
        {
            _context.Konties.Remove(Konto);
        }


    }
}
