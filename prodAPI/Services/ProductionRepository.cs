using Microsoft.EntityFrameworkCore;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class ProductionRepository : IProductionRepository
    {
        private production_dbContext _context;

        public ProductionRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<ProduktyDto?> GetProduktyAsync(int idProduktu)
        {
            return await _context.Produkties.Where(c=>c.IdProduktu==idProduktu).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<ProduktyDto>> GetProduktyAsync()
        {
            return await _context.Produkties.OrderBy(c=>c.Nazwa).ToListAsync();
        }

        public async Task<EtapyDto?> GetEtapyAsync(int idEtapu)
        {
            return await _context.Etapies.Where(c=>c.IdEtapu == idEtapu).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EtapyDto>> GetEtapyAsync()
        {
            return await _context.Etapies.OrderBy(c => c.Nazwa).ToListAsync();
        }


    }
}
