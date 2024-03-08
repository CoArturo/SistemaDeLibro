using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Estante
    {
        public Estante()
        {
            Libros = new HashSet<Libro>();
        }

        public int EstanteId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Ubicacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
