using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;
using prodAPI.Models;

namespace prodAPI.Services
{
    public class StatusRepository : IStatusRepository
    {
        private production_dbContext _context;

        public StatusRepository(production_dbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<StatusDto?> GetStatusAsync(int idStatusu)
        {
            return await _context.Statuses.Where(c=>c.IdStatusu==idStatusu).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<StatusDto>> GetStatusAsync()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task AddStatusAsync(StatusDto Status)
        {
            _context.Statuses.Add(Status);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public void DeleteStatus(StatusDto Status)
        {
            _context.Statuses.Remove(Status);
        }


    }
}
