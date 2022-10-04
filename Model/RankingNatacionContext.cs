using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NatacionProyecto.Model
{
    public partial class RankingNatacionContext : DbContext
    {
        public RankingNatacionContext()
        {
        }

        public RankingNatacionContext(DbContextOptions<RankingNatacionContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Estilo> Estilos { get; set; } = null!;
        public virtual DbSet<Medida> Medidas { get; set; } = null!;
        public virtual DbSet<MetricasNadadore> MetricasNadadores { get; set; } = null!;
        public virtual DbSet<Nadadore> Nadadores { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<TipoIdentificacione> TipoIdentificaciones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GKCDL1H ;Database=RankingNatacion;Trusted_Connection=True;");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estilo>(entity =>
            {
                entity.Property(e => e.NombreEstilo)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.Property(e => e.Medida1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Medida");
            });

            modelBuilder.Entity<MetricasNadadore>(entity =>
            {
                entity.Property(e => e.Distancia).HasColumnType("numeric(5, 2)");

                entity.Property(e => e.FechaMetrica).HasColumnType("datetime");

                entity.HasOne(d => d.Estilo)
                    .WithMany(p => p.MetricasNadadores)
                    .HasForeignKey(d => d.EstiloId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EstiloMetricasNadadores");

                entity.HasOne(d => d.MedidaDistancia)
                    .WithMany(p => p.MetricasNadadores)
                    .HasForeignKey(d => d.MedidaDistanciaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedidasMetricasNadador");

                entity.HasOne(d => d.Nadador)
                    .WithMany(p => p.MetricasNadadores)
                    .HasForeignKey(d => d.NadadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NadadorMetricasNadadores");
            });

            modelBuilder.Entity<Nadadore>(entity =>
            {
                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Liga)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Persona)
                    .WithMany(p => p.Nadadores)
                    .HasForeignKey(d => d.PersonaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonasNadadores");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasIndex(e => e.Identificacion, "Personas")
                    .IsUnique();

                entity.Property(e => e.Cedula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.TipoIdentificacion)
                    .WithMany(p => p.InverseTipoIdentificacion)
                    .HasForeignKey(d => d.TipoIdentificacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonasTipoIdentificaciones");
            });

            modelBuilder.Entity<TipoIdentificacione>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
