using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Multum
    {
        public int MultaId { get; set; }
        public int? UsuarioId { get; set; }
        public decimal? Monto { get; set; }
        public string? Motivo { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
