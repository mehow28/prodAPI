using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
using prodAPI.Entities;

namespace prodAPI.Services
{
    public interface IStatusRepository
    {
        Task<IEnumerable<StatusDto>> GetStatusAsync();
        Task<StatusDto?> GetStatusAsync(int idStatusu);
        Task AddStatusAsync(StatusDto status);

        void DeleteStatus(StatusDto status);
        Task<bool> SaveChangesAsync();
    }
}
