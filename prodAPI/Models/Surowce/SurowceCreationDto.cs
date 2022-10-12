using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class SurowceCreationDto
    {
        
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
    }
}
