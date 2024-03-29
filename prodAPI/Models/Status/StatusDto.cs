﻿using System;
using System.Collections.Generic;

namespace prodAPI.Models
{
    public partial class StatusDto
    {
        public int IdStatusu { get; set; }
        public int IdZlecenia { get; set; }
        public int? IdMaszyny { get; set; }
        public int IdPracownika { get; set; }
        public int IdEtapu { get; set; }
        public bool Stan { get; set; }
        public int CzasTrwania { get; set; }
        public string? Notatki { get; set; }
        public virtual EtapyDto IdEtapuNavigation { get; set; } = null!;
        public virtual MaszynyDto? IdMaszynyNavigation { get; set; }
        public virtual PracownicyDto IdPracownikaNavigation { get; set; } = null!;
        public virtual ZleceniumDto IdZleceniaNavigation { get; set; } = null!;
    }
}
