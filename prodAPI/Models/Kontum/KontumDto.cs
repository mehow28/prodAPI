using System;
using System.Collections.Generic;

namespace prodAPI.Models
{
    public partial class KontumDto
    {
        public int IdKonta { get; set; }
        public string Login { get; set; } = null!;
        public byte[] Haslo { get; set; } = null!;
        public string Uprawnienia { get; set; } = null!;
        public int IdPracownika { get; set; }

        public virtual PracownicyDto IdPracownikaNavigation { get; set; } = null!;
    }
}
