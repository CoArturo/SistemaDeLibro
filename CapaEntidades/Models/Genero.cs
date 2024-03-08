using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Genero
    {
        public Genero()
        {
            DetalleGeneros = new HashSet<DetalleGenero>();
            Libros = new HashSet<Libro>();
        }

        public int GeneroId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<DetalleGenero> DetalleGeneros { get; set; }
        public virtual ICollection<Libro> Libros { get; set; }
    }
}
