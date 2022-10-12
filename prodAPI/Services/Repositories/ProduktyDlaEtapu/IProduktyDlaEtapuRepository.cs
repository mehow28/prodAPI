using prodAPI.Models;

namespace prodAPI.Services
{
    public interface IProduktyDlaEtapuRepository
    {
        Task<(IEnumerable<SurowceDlaEtapuDto>,PaginationMetadata)> GetProduktyDlaEtapuAsync(
            int? idEtapu, int? idProduktu,
            int pageNumber, int pageSize);
        Task<SurowceDlaEtapuDto?> GetProduktDlaEtapuAsync(int id);
        Task AddProduktyDlaEtapuAsync(SurowceDlaEtapuDto pde);

        void DeleteProduktyDlaEtapu(SurowceDlaEtapuDto pde);
        Task<bool> SaveChangesAsync();
    }
}
