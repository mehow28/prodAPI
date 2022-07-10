using System;
using System.Collections.Generic;

namespace prodAPI.Models
{
    public partial class ProduktyDto
    {
        public ProduktyDto()
        {
            Etapies = new HashSet<EtapyDto>();
            Statuses = new HashSet<StatusDto>();
            Zlecenia = new HashSet<ZleceniumDto>();
        }

        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;

        public virtual ICollection<EtapyDto> Etapies { get; set; }
        public virtual ICollection<StatusDto> Statuses { get; set; }
        public virtual ICollection<ZleceniumDto> Zlecenia { get; set; }
    }
}
