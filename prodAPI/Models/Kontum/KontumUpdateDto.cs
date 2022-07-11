using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prodAPI.Models
{
    public partial class KontumUpdateDto
    {

        [MaxLength(50)]
        public string Login { get; set; } = null!;
        [MaxLength(64)]
        public byte[] Haslo { get; set; } = null!;
        [MaxLength(50)]
        public string Uprawnienia { get; set; } = null!;
        public int IdPracownika { get; set; }
    }
}
