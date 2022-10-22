using System;
using System.Collections.Generic;

namespace prodAPI.Models
{
    public partial class EtapyDto
    {
        public EtapyDto()
        {
            StrukturyWyrobus = new HashSet<StrukturyWyrobuDto>();
            SurowceDlaEtapus = new HashSet<SurowceDlaEtapuDto>();
            Statuses = new HashSet<StatusDto>();
        }

        public int IdEtapu { get; set; }
        public string Nazwa { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public int Czas { get; set; }

        public virtual ICollection<StrukturyWyrobuDto> StrukturyWyrobus { get; set; }

        public virtual ICollection<SurowceDlaEtapuDto> SurowceDlaEtapus { get; set; }
        public virtual ICollection<StatusDto> Statuses { get; set; }
    }
}
