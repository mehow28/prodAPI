using System;
using System.Collections.Generic;

namespace productionAPI.Models
{
    public partial class PracownicyDto
    {
        public PracownicyDto()
        {
            Konta = new HashSet<KontumDto>();
            Statuses = new HashSet<StatusDto>();
        }

        public int IdPracownika { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NrTel { get; set; } = null!;

        public virtual ICollection<KontumDto> Konta { get; set; }
        public virtual ICollection<StatusDto> Statuses { get; set; }
    }
}
