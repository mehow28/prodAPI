using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Entities
{
    public partial class Kontum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdKonta { get; set; }
        public string Login { get; set; } = null!;
        public byte[] Haslo { get; set; } = null!;
        public string Uprawnienia { get; set; } = null!;
        [ForeignKey("IdPracownika")]
        public Pracownicy? Pracownicy { get; set; }
        public int IdPracownika { get; set; }

        public Kontum(string login, byte[] haslo, string uprawnienia)
        {
            Login = login;
            Haslo = haslo;
            Uprawnienia=uprawnienia;
        }

    }
}
