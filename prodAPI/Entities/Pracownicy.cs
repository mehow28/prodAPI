using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Entities
{
    public partial class Pracownicy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPracownika { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string NrTel { get; set; } = null!;
        public virtual ICollection<Kontum> Konta { get; set; }
            = new List<Kontum>();
        public virtual ICollection<Status> Statuses { get; set; }
            = new List<Status>();
        public Pracownicy(string imie, string nazwisko, string email, string nrtel)
        {
            Imie = imie;
            Nazwisko= nazwisko;
            Email = email;
            NrTel = nrtel;
        }
    }
}
