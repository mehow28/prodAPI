using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class AwariaDto
    {
        public AwariaDto()
        {
            Maszyny = new HashSet<MaszynyDto>();
        }
       
        public int IdAwarii { get; set; }
        public bool Stan { get; set; }
        public DateTime DataZgloszenia { get; set; }
        public string Opis { get; set; } = null!;

        public virtual ICollection<MaszynyDto> Maszyny { get; set; }
    }
}
