using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class EtapyUpdateDto
    {
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
        [MaxLength(50)]
        public string Opis { get; set; } = null!;

        public int Czas { get; set; }

    }
}
