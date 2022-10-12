using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class MaszynyCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Marka { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Model { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Opis { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string? Nazwa { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Kategoria { get; set; }

        public DateTime? DataPrzegladu { get; set; }
    }
}
