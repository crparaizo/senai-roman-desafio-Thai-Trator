using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Roman.WebApi.Domains
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipes> Equipes { get; set; }
        public virtual DbSet<Projetos> Projetos { get; set; }
        public virtual DbSet<Situacoes> Situacoes { get; set; }
        public virtual DbSet<Temas> Temas { get; set; }
        public virtual DbSet<TiposUsuarios> TiposUsuarios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosEquipes> UsuariosEquipes { get; set; }

        // Unable to generate entity type for table 'dbo.USUARIOS_EQUIPES'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog=DESAFIO_ROMAN; user id=sa; pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosEquipes>()
            .HasKey(x => new { x.IdUsuario, x.IdEquipe });


            modelBuilder.Entity<UsuariosEquipes>()
                .HasOne<Usuarios>(sc => sc.Usuarios)
                .WithMany(s => s.UsuariosEquipes)
                .HasForeignKey(sc => sc.IdUsuario);

            modelBuilder.Entity<UsuariosEquipes>()
                .HasOne<Equipes>(sc => sc.Equipes)
                .WithMany(s => s.UsuariosEquipes)
                .HasForeignKey(sc => sc.IdEquipe);

            modelBuilder.Entity<Equipes>(entity =>
            {
                entity.ToTable("EQUIPES");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__EQUIPES__E2AB1FF4C1C444C8")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Projetos>(entity =>
            {
                entity.ToTable("PROJETOS");

                entity.HasIndex(e => e.Titulo)
                    .HasName("UQ__PROJETOS__AC728E50187EC148")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Descricao)
                    .HasColumnName("DESCRICAO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdTema).HasColumnName("ID_TEMA");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("TITULO")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__PROJETOS__ID_TEM__08B54D69");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PROJETOS__ID_USU__09A971A2");
            });

            modelBuilder.Entity<Situacoes>(entity =>
            {
                entity.ToTable("SITUACOES");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__SITUACOE__E2AB1FF438406CBB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Temas>(entity =>
            {
                entity.ToTable("TEMAS");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TEMAS__E2AB1FF425523EE6")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.IdSituacao).HasColumnName("ID_SITUACAO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdSituacaoNavigation)
                    .WithMany(p => p.Temas)
                    .HasForeignKey(d => d.IdSituacao)
                    .HasConstraintName("FK__TEMAS__ID_SITUAC__01142BA1");
            });

            modelBuilder.Entity<TiposUsuarios>(entity =>
            {
                entity.ToTable("TIPOS_USUARIOS");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TIPOS_US__E2AB1FF4FCBC5FD9")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF7249AF4D4D5")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("NOME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIOS__ID_TIP__04E4BC85");
            });
        }
    }
}
