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
            StrukturyWyrobus = new HashSet<StrukturyWyrobuDto>();
            Zlecenia = new HashSet<ZleceniumDto>();
        }
       
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;

        public virtual ICollection<StrukturyWyrobuDto> StrukturyWyrobus { get; set; }
        public virtual ICollection<ZleceniumDto> Zlecenia { get; set; }
    }
}
