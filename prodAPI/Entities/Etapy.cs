using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Entities
{
    public partial class Etapy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEtapu { get; set; }
        [ForeignKey("IdProduktu")]
        public Produkty? Produkty{ get; set; }

        public int IdProduktu { get; set; }
        public string Nazwa { get; set; } = null!;
        public string Czas { get; set; } = null!;
        public int Kolejnosc { get; set; }
        public virtual ICollection<Status> Statuses { get; set; }
            = new List<Status>();

        public Etapy(string nazwa, string czas)
        {
            Nazwa = nazwa; 
            Czas = czas;
        }
    }
}
