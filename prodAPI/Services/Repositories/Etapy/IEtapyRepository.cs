using prodAPI.Models;

namespace prodAPI.Services
{
    public interface IEtapyRepository
    {
        Task<IEnumerable<EtapyDto>> GetEtapyAsync();
        Task<EtapyDto?> GetEtapyAsync(int idEtapu);
        Task AddEtapAsync(EtapyDto Etap);

        void DeleteEtap(EtapyDto Etap);
        Task<bool> SaveChangesAsync();
    }
}
