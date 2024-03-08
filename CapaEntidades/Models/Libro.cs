using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Libro
    {
        public Libro()
        {
            DetalleGeneros = new HashSet<DetalleGenero>();
            Prestamos = new HashSet<Prestamo>();
        }

        public int LibroId { get; set; }
        public string Titulo { get; set; } = null!;
        public string? RutaPortada { get; set; }
        public int? AutorId { get; set; }
        public int? EstanteId { get; set; }
        public int? GeneroId { get; set; }

        public virtual Autor? Autor { get; set; }
        public virtual Estante? Estante { get; set; }
        public virtual Genero? Genero { get; set; }
        public virtual ICollection<DetalleGenero> DetalleGeneros { get; set; }
        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
