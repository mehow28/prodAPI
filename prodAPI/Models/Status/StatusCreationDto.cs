using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class StatusCreationDto
    {
        public bool Stan { get; set; }


        [ForeignKey("IdZlecenia")]
        public int IdZlecenia { get; set; }


        [ForeignKey("IdPracownika")]
        public int IdPracownika { get; set; }

        [ForeignKey("IdEtapu")]
        public int IdEtapu { get; set; }
        [ForeignKey("IdMaszyny")]
        public int? IdMaszyny { get; set; }
        public DateTime? DataRozpoczecia { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public string Notatki { get; set; } = null!;
    }
}
