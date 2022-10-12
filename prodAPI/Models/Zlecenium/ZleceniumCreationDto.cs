using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class ZleceniumCreationDto
    {
        public DateTime? DataRozpoczecia { get; set; }
        public int Ilosc { get; set; }
        public bool? Stan { get; set; }
        public int IdProduktu { get; set; }
        public DateTime? DataZakonczenia { get; set; }
        public string? Opis { get; set; } = null!;

    }
}
