using Azure;

namespace prodAPI.Models.StrukturyWyrobu
{
    public class StrukturyWyrobuCreationDto
    {
        public int IdProduktu { get; set; }
        public int IdEtapu { get; set; }
        public int Kolejnosc { get; set; }

    }
}
