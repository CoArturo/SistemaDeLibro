using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Autor
    {
        public Autor()
        {
            Libros = new HashSet<Libro>();
        }

        public int AutorId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
