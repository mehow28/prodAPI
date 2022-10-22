using Azure;

namespace prodAPI.Models.StrukturyWyrobu
{
    public class StrukturyWyrobuUpdateDto
    {
        public int IdProduktu { get; set; }
        public int IdEtapu { get; set; }
        public int Kolejnosc { get; set; }

    }
}
