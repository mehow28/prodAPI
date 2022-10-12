using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class SurowceDto
    {
        public SurowceDto()
        {
            SurowceDlaEtapus = new HashSet<SurowceDlaEtapuDto>();
        }
       
        public int IdSurowca { get; set; }
        public string Nazwa { get; set; } = null!;

        public virtual ICollection<SurowceDlaEtapuDto> SurowceDlaEtapus { get; set; }
    }
}
