using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class ProduktyUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
    }
}
