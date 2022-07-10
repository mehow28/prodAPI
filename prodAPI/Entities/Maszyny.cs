using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Entities
{
    public partial class Maszyny
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMaszyny { get; set; }
        public string? Nazwa { get; set; }
        public string Marka { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Opis { get; set; } = null!;
        public DateTime DataPrzegladu { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
            = new List<Status>();

        public Maszyny(string nazwa, string marka, string model, string opis)
        {
            Nazwa = nazwa;
            Marka = marka;
            Model = model;
            Opis = opis;
        }
    }
}
