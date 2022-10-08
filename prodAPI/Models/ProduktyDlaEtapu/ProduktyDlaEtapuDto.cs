using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class ProduktyDlaEtapuDto
    {
        public int Id { get; set; }
        public bool Stan { get; set; }
        public int PotrzebnaIlosc { get; set; }
        public int? FaktycznaIlosc { get; set; }
        public int IdEtapu { get; set; }
        public int IdProduktu { get; set; }

        public virtual EtapyDto IdEtapuNavigation { get; set; } = null!;
        public virtual ProduktyDto IdProduktuNavigation { get; set; } = null!;
    }
}
