using System;
using System.Collections.Generic;

namespace productionAPI.Models
{
    public partial class EtapyCreationDto
    {
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;
        public string Czas { get; set; } = null!;
        public int Kolejnosc { get; set; }
    }
}
