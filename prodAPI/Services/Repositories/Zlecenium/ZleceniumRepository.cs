using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class ZleceniumRepository : IZleceniumRepository
    {
        private production_dbContext _context;

        public ZleceniumRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ZleceniumDto?> GetZleceniumAsync(int idZlecenia)
        {
            return await _context.Zlecenia.Where(c=>c.IdZlecenia==idZlecenia).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ZleceniumDto>> GetZleceniumAsync()
        {
            return await _context.Zlecenia.ToListAsync();
        }

        public async Task AddZleceniumAsync(ZleceniumDto Zlecenium)
        {
            _context.Zlecenia.Add(Zlecenium);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteZlecenium(ZleceniumDto Zlecenium)
        {
            _context.Zlecenia.Remove(Zlecenium);
        }


    }
}
