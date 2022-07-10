using prodAPI.Models;

namespace prodAPI
{
    public class EtapyDataStore
    {
        public List<EtapyDto> Etapy { get; set; }
        public static EtapyDataStore Current { get; } = new EtapyDataStore();

        public EtapyDataStore()
        {
            Etapy = new List<EtapyDto>()
            {
                new EtapyDto
                {
                    IdEtapu=1,
                    IdProduktu=1,
                    Nazwa="Nazwa1",
                    Czas="Czas1",
                    Kolejnosc=1
                },
                new EtapyDto
                {
                    IdEtapu=2,
                    IdProduktu=2,
                    Nazwa="Nazwa2",
                    Czas="Czas2",
                    Kolejnosc=2
                },
                new EtapyDto
                {
                    IdEtapu=3,
                    IdProduktu=3,
                    Nazwa="Nazwa3",
                    Czas="Czas3",
                    Kolejnosc=3
                },
                new EtapyDto
                {
                    IdEtapu=4,
                    IdProduktu=4,
                    Nazwa="Nazwa4",
                    Czas="Czas4",
                    Kolejnosc=4
                }
            };
        }
    }
}
