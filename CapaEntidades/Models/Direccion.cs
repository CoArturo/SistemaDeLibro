using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int DireccionId { get; set; }
        public string? Calle { get; set; }
        public string? Ciudad { get; set; }
        public string? Estado { get; set; }
        public string? CodigoPostal { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
