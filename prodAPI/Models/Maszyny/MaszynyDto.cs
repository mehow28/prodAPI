using System;
using System.Collections.Generic;

namespace prodAPI.Models
{
    public partial class MaszynyDto
    {
        public MaszynyDto()
        {
            Statuses = new HashSet<StatusDto>();
        }

        public int IdMaszyny { get; set; }
        public string? Nazwa { get; set; }
        public string Marka { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public DateTime DataPrzegladu { get; set; }

        public virtual ICollection<StatusDto> Statuses { get; set; }
    }
}
