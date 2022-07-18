using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class KontumCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Haslo { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Uprawnienia { get; set; } = null!;
       
        public int IdPracownika { get; set; }
    }
}
