using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class AwariaUpdateDto
    {
        [Required]
        public bool Stan { get; set; }
        [Required]
        public DateTime DataZgloszenia { get; set; }
        [Required]
        public string Opis { get; set; } = null!;
    }
}
