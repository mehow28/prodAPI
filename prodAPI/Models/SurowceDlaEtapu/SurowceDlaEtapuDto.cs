using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class SurowceDlaEtapuDto
    {
        public int Id { get; set; }
        public bool Stan { get; set; }
        public int PotrzebnaIlosc { get; set; }
        public int? FaktycznaIlosc { get; set; }
        public int IdEtapu { get; set; }
        public int IdSurowca { get; set; }

        public virtual EtapyDto IdEtapuNavigation { get; set; } = null!;
        public virtual SurowceDto IdProduktuNavigation { get; set; } = null!;
    }
}
