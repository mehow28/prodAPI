using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class EtapyCreationDto
    {
        public int IdProduktu { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string Czas { get; set; } = null!;
        public int Kolejnosc { get; set; }
    }
}
