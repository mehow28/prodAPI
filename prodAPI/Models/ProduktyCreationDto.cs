﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace productionAPI.Models
{
    public partial class ProduktyCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
    }
}
