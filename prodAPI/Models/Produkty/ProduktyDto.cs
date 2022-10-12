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
            Zlecenia = new HashSet<ZleceniumDto>();
        }
       
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;

        public virtual ICollection<ZleceniumDto> Zlecenia { get; set; }
    }
}
