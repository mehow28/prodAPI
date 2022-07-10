using prodAPI.Models;

namespace prodAPI
{
    public class ProduktyDataStore
    {
        public List<ProduktyDto> Produkty { get; set; }
        public static ProduktyDataStore Current { get; } = new ProduktyDataStore();

        public ProduktyDataStore()
        {
            Produkty = new List<ProduktyDto>()
            {
                new ProduktyDto
                {
                    IdProduktu = 1,
                    Nazwa = "Prod1"
                },
                new ProduktyDto
                {
                    IdProduktu = 2,
                    Nazwa = "Prod2"
                },
                new ProduktyDto
                {
                    IdProduktu = 3,
                    Nazwa = "Prod3"
                },
                new ProduktyDto
                {
                    IdProduktu = 4,
                    Nazwa = "Prod4"
                }
            };  
        }
    }
}
