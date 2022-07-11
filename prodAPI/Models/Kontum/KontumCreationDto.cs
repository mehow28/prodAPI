﻿using System;
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
        [MaxLength(64)]
        public byte[] Haslo { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Uprawnienia { get; set; } = null!;
        [Required]
        public int IdPracownika { get; set; }
    }
}
