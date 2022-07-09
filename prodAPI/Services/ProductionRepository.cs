using Microsoft.EntityFrameworkCore;
using productionAPI.Models;

namespace prodAPI.Services
{
    public class ProductionRepository : IProductionRepository
    {
        private production_dbContext _context;

        public ProductionRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<ProduktyDto>> GetProduktyAsync()
        {
            return await _context.Produkties.OrderBy(c=>c.Nazwa).ToListAsync();
        }
    }
}
