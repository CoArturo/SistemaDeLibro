using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Multa = new HashSet<Multum>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Email { get; set; }
        public int? DireccionId { get; set; }
        public bool? Estado { get; set; }

        public virtual Direccion? Direccion { get; set; }
        public virtual ICollection<Multum> Multa { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
