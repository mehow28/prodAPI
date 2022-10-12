using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class SurowceDlaEtapuUpdateDto
    {

        [Required]
        public bool Stan { get; set; }
        [Required]
        public int IdEtapu { get; set; }
        [Required]
        public int FaktycznaIlosc { get; set; }
        [Required]
        public int IdSurowca { get; set; }
    }
}
