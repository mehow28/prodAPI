﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace productionAPI.Models
{
    public partial class ProduktyUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
    }
}
