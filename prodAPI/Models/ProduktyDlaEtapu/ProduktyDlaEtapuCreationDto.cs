using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class ProduktyDlaEtapuCreationDto
    {
        
        [Required]
        public bool Stan { get; set; }
        [Required]
        public int IdEtapu { get; set; }
        [Required]
        public int PotrzebnaIlosc { get; set; }
        [Required]
        public int IdProduktu { get; set; }
    }
}
