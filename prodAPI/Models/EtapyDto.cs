using System;
using System.Collections.Generic;

namespace productionAPI.Models
{
    public partial class EtapyDto
    {
        public EtapyDto()
        {
            Statuses = new HashSet<StatusDto>();
        }

        public int IdEtapu { get; set; }
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;
        public string Czas { get; set; } = null!;
        public int Kolejnosc { get; set; }

        public virtual ProduktyDto IdProduktuNavigation { get; set; } = null!;
        public virtual ICollection<StatusDto> Statuses { get; set; }
    }
}
