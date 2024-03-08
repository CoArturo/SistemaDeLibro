using System;
using System.Collections.Generic;

namespace CapaEntidades.Models
{
    public partial class Prestamo
    {
        public int PrestamoId { get; set; }
        public int? UsuarioId { get; set; }
        public int? LibroId { get; set; }
        public DateTime? FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Libro? Libro { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
