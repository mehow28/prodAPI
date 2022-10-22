using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class EtapyCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Opis { get; set; } = null!;

        public int Czas { get; set; }

    }
}
