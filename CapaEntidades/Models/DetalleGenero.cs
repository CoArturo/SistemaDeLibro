using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class DetalleGenero
    {
        public int DetalleGeneroId { get; set; }
        public int? LibroId { get; set; }
        public int? GeneroId { get; set; }

        public virtual Genero? Genero { get; set; }
        public virtual Libro? Libro { get; set; }
    }
}
