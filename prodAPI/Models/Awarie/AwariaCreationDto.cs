using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class AwariaCreationDto
    {

        [Required]
        public bool Stan { get; set; }
        [Required]
        public DateTime DataZgloszenia { get; set; }
        [Required]
        public string Opis { get; set; } = null!;
    }
}
