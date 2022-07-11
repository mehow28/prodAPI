using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class EtapyUpdateDto
    {
        public int IdProduktu { get; set; }
        [MaxLength(50)]
        public string Nazwa { get; set; } = null!;
        [MaxLength(50)]
        public string Czas { get; set; } = null!;
        public int Kolejnosc { get; set; }
    }
}
