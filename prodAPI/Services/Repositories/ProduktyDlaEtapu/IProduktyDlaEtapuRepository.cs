using prodAPI.Models;

namespace prodAPI.Services
{
    public interface IProduktyDlaEtapuRepository
    {
        Task<(IEnumerable<ProduktyDlaEtapuDto>,PaginationMetadata)> GetProduktyDlaEtapuAsync(
            int? idEtapu, int? idProduktu,
            int pageNumber, int pageSize);
        Task<ProduktyDlaEtapuDto?> GetProduktDlaEtapuAsync(int id);
        Task AddProduktyDlaEtapuAsync(ProduktyDlaEtapuDto pde);

        void DeleteProduktyDlaEtapu(ProduktyDlaEtapuDto pde);
        Task<bool> SaveChangesAsync();
    }
}
