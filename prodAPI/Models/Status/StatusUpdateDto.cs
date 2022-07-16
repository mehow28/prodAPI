﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prodAPI.Models
{
    public partial class StatusUpdateDto
    {
        [ForeignKey("IdProduktu")]
        public int IdProduktu { get; set; }

        [ForeignKey("IdZlecenia")]
        public int IdZlecenia { get; set; }

        [ForeignKey("IdMaszyny")]
        public int? IdMaszyny { get; set; }

        [ForeignKey("IdPracownika")]
        public int IdPracownika { get; set; }

        [ForeignKey("IdEtapu")]
        public int IdEtapu { get; set; }
        public bool Status { get; set; }
        public int CzasTrwania { get; set; }
    }
}