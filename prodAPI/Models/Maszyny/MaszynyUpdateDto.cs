using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class MaszynyUpdateDto
    {
        [MaxLength(50)]
        public string? Nazwa { get; set; }
        [MaxLength(50)]
        public string Marka { get; set; } = null!;
        [MaxLength(50)]
        public string Model { get; set; } = null!;
        [MaxLength(50)]
        public string Opis { get; set; } = null!;
        
        public DateTime DataPrzegladu { get; set; }
    }
}
