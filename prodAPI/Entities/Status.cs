using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Entities
{
    public partial class Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdStatusu { get; set; }
     
        [ForeignKey("IdProduktu")]
        public Produkty? Produkty { get; set; }
        public int IdProduktu { get; set; }
        
        [ForeignKey("IdZlecenia")]
        public Zlecenium? Zlecenium{ get; set; }
        public int IdZlecenia { get; set; }
       
        [ForeignKey("IdMaszyny")]
        public Maszyny? Maszyny{ get; set; }
        public int? IdMaszyny { get; set; }
       
        [ForeignKey("IdPracownika")]
        public Pracownicy? Pracownicy { get; set; }
        public int IdPracownika { get; set; }
        
        [ForeignKey("IdEtapu")]
        public Etapy? Etapy{ get; set; }
        public int IdEtapu { get; set; }
        
        public bool Status1 { get; set; }
        
        public int CzasTrwania { get; set; }

    }
}
