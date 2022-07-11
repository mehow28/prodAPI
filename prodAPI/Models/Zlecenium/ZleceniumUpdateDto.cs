using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class ZleceniumUpdateDto
    {
        public DateTime? Data { get; set; }
        [ForeignKey("IdProduktu")]
        public int? IdProduktu { get; set; }
        public int? Ilosc { get; set; }
    }
}
