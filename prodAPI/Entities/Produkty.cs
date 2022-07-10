using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Entities
{
    public partial class Produkty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;
        public virtual ICollection<Etapy> Etapies { get; set; }
            = new List<Etapy>();
        public virtual ICollection<Status> Statuses { get; set; }
            = new List<Status>();
        public virtual ICollection<Zlecenium> Zlecenia { get; set; }
            = new List<Zlecenium>();
        public Produkty(string nazwa)
        {
            Nazwa= nazwa;
        }
    }
}
