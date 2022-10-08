using System;
using System.Collections.Generic;

namespace prodAPI.Models
{
    public partial class ZleceniumDto
    {
        public ZleceniumDto()
        {
            Statuses = new HashSet<StatusDto>();
        }

        public int IdZlecenia { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public int Ilosc { get; set; }
        public bool Stan { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public string Opis { get; set; } = null!;

        public virtual ICollection<StatusDto> Statuses { get; set; }
    }
}
