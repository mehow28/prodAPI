using Microsoft.EntityFrameworkCore;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class EtapyRepository : IEtapyRepository
    {
        private production_dbContext _context;

        public EtapyRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<EtapyDto?> GetEtapyAsync(int idEtapu)
        {
            return await _context.Etapies.Where(c => c.IdEtapu == idEtapu).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EtapyDto>> GetEtapyAsync()
        {
            return await _context.Etapies.OrderBy(c => c.IdEtapu).ToListAsync();
        }

        public async Task AddEtapAsync(EtapyDto Etap)
        {
            _context.Etapies.Add(Etap);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteEtap(EtapyDto Etap)
        {
            _context.Etapies.Remove(Etap);
        }
    }
}
