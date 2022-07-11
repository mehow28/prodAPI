using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class PracownicyUpdateDto
    {
        [MaxLength(50)]
        public string Imie { get; set; } = null!;
        [MaxLength(50)]
        public string Nazwisko { get; set; } = null!;
        [MaxLength(50)]
        public string Email { get; set; } = null!;
        [MaxLength(50)]
        public string NrTel { get; set; } = null!;
    }
}
