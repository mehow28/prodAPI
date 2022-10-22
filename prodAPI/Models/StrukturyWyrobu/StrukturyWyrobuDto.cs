using Azure;

namespace prodAPI.Models.StrukturyWyrobu
{
    public class StrukturyWyrobuDto
    {
        public int Id { get; set; }
        public int IdProduktu { get; set; }
        public int IdEtapu { get; set; }
        public int Kolejnosc { get; set; }

        public virtual EtapyDto IdEtapuNavigation { get; set; } = null!;
        public virtual ProduktyDto IdProduktuNavigation { get; set; } = null!;
    }
}
