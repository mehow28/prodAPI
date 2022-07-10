using prodAPI.Models;
using Microsoft.EntityFrameworkCore;
    
namespace prodAPI.Services
{
    public interface IProductionRepository
    {
        Task<IEnumerable<EtapyDto>> GetEtapyAsync();
        Task<EtapyDto?> GetEtapyAsync(int idEtapu);
        Task<IEnumerable<ProduktyDto>> GetProduktyAsync();
        Task<ProduktyDto?> GetProduktyAsync(int idProduktu);
    }
}
