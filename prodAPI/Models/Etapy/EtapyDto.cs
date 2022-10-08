using System;
using System.Collections.Generic;

namespace prodAPI.Models
{
    public partial class EtapyDto
    {
        public EtapyDto()
        {
            ProduktyDlaEtapus = new HashSet<ProduktyDlaEtapuDto>();
            Statuses = new HashSet<StatusDto>();
        }

        public int IdEtapu { get; set; }
        public string Nazwa { get; set; } = null!;
        public string Opis { get; set; } = null!;

        public virtual ICollection<ProduktyDlaEtapuDto> ProduktyDlaEtapus { get; set; }
        public virtual ICollection<StatusDto> Statuses { get; set; }
    }
}
