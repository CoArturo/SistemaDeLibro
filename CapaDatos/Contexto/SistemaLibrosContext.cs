using System;
using System.Collections.Generic;
using CapaEntidades.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CapaDatos.Contexto
{
    public partial class SistemaLibrosContext : DbContext
    {
        public SistemaLibrosContext()
        {
        }

        public SistemaLibrosContext(DbContextOptions<SistemaLibrosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; } = null!;
        public virtual DbSet<DetalleGenero> DetalleGeneros { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!;
        public virtual DbSet<Estante> Estantes { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Multum> Multa { get; set; } = null!;
        public virtual DbSet<Prestamo> Prestamos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ARTURO\\SQLEXPRESS; Database=SistemaLibros; Trusted_Connection=true; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.ToTable("Autor");

                entity.Property(e => e.AutorId)
                    .ValueGeneratedNever()
                    .HasColumnName("AutorID");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<DetalleGenero>(entity =>
            {
                entity.ToTable("DetalleGenero");

                entity.Property(e => e.DetalleGeneroId)
                    .ValueGeneratedNever()
                    .HasColumnName("DetalleGeneroID");

                entity.Property(e => e.GeneroId).HasColumnName("GeneroID");

                entity.Property(e => e.LibroId).HasColumnName("LibroID");

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.DetalleGeneros)
                    .HasForeignKey(d => d.GeneroId)
                    .HasConstraintName("FK__DetalleGe__Gener__44FF419A");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.DetalleGeneros)
                    .HasForeignKey(d => d.LibroId)
                    .HasConstraintName("FK__DetalleGe__Libro__440B1D61");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.ToTable("Direccion");

                entity.Property(e => e.DireccionId)
                    .ValueGeneratedNever()
                    .HasColumnName("DireccionID");

                entity.Property(e => e.Calle).HasMaxLength(255);

                entity.Property(e => e.Ciudad).HasMaxLength(100);

                entity.Property(e => e.CodigoPostal).HasMaxLength(20);

                entity.Property(e => e.Estado).HasMaxLength(100);
            });

            modelBuilder.Entity<Estante>(entity =>
            {
                entity.ToTable("Estante");

                entity.Property(e => e.EstanteId)
                    .ValueGeneratedNever()
                    .HasColumnName("EstanteID");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Ubicacion).HasMaxLength(255);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.ToTable("Genero");

                entity.Property(e => e.GeneroId)
                    .ValueGeneratedNever()
                    .HasColumnName("GeneroID");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.ToTable("Libro");

                entity.Property(e => e.LibroId)
                    .ValueGeneratedNever()
                    .HasColumnName("LibroID");

                entity.Property(e => e.AutorId).HasColumnName("AutorID");

                entity.Property(e => e.EstanteId).HasColumnName("EstanteID");

                entity.Property(e => e.GeneroId).HasColumnName("GeneroID");

                entity.Property(e => e.RutaPortada)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Titulo).HasMaxLength(255);

                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.AutorId)
                    .HasConstraintName("FK__Libro__AutorID__403A8C7D");

                entity.HasOne(d => d.Estante)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.EstanteId)
                    .HasConstraintName("FK__Libro__EstanteID__412EB0B6");

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.GeneroId)
                    .HasConstraintName("FK__Libro__GeneroID__3F466844");
            });

            modelBuilder.Entity<Multum>(entity =>
            {
                entity.HasKey(e => e.MultaId)
                    .HasName("PK__Multa__DA090D8025508215");

                entity.Property(e => e.MultaId)
                    .ValueGeneratedNever()
                    .HasColumnName("MultaID");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Monto).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Motivo).HasMaxLength(255);

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Multa)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Multa__UsuarioID__5165187F");
            });

            modelBuilder.Entity<Prestamo>(entity =>
            {
                entity.ToTable("Prestamo");

                entity.Property(e => e.PrestamoId)
                    .ValueGeneratedNever()
                    .HasColumnName("PrestamoID");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaDevolucion).HasColumnType("date");

                entity.Property(e => e.FechaPrestamo).HasColumnType("date");

                entity.Property(e => e.LibroId).HasColumnName("LibroID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.LibroId)
                    .HasConstraintName("FK__Prestamo__LibroI__4D94879B");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Prestamos)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK__Prestamo__Usuari__4CA06362");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.UsuarioId)
                    .ValueGeneratedNever()
                    .HasColumnName("UsuarioID");

                entity.Property(e => e.DireccionId).HasColumnName("DireccionID");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Estado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.Direccion)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.DireccionId)
                    .HasConstraintName("FK__Usuario__Direcci__48CFD27E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
