using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class ProduktyDto
    {
        public ProduktyDto()
        {
            ProduktyDlaEtapus = new HashSet<ProduktyDlaEtapuDto>();
            Statuses = new HashSet<StatusDto>();
        }
       
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;

        public virtual ICollection<ProduktyDlaEtapuDto> ProduktyDlaEtapus { get; set; }
        public virtual ICollection<StatusDto> Statuses { get; set; }
    }
}
