using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class PracownicyCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Imie { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Nazwisko { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Nrtel { get; set; } = null!;
    }
}
