using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Entities
{
    public partial class Zlecenium
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdZlecenia { get; set; }
        public DateTime? Data { get; set; }
        [ForeignKey("IdProduktu")]
        public Produkty? Produkty { get; set; }

        public int? IdProduktu { get; set; }
        public int? Ilosc { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
            = new List<Status>();

    }
}
