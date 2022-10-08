using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class ProduktyDlaEtapuUpdateDto
    {

        [Required]
        public bool Stan { get; set; }
        [Required]
        public int IdEtapu { get; set; }
        [Required]
        public int? FaktycznaIlosc { get; set; }
        [Required]
        public int IdProduktu { get; set; }
    }
}
