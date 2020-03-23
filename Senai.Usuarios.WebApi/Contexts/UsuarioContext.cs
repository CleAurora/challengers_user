using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai.Usuarios.WebApi.Domains;

namespace Senai.Usuarios.WebApi.Contexts
{
    public partial class UsuarioContext : DbContext
    {
        public UsuarioContext()
        {
        }

        public UsuarioContext(DbContextOptions<UsuarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Habilidades> Habilidades { get; set; }
        public virtual DbSet<Perfis> Perfis { get; set; }
        public virtual DbSet<Profissoes> Profissoes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=Challenger_User; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Habilidades>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__0DD4B30D941E8E37");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perfis>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfis__C7BD5CC1E30EE114");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profissoes>(entity =>
            {
                entity.HasKey(e => e.IdProfissao)
                    .HasName("PK__Profisso__A367C1F66E904FBA");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF97FB840D86");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Imagem)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SitePessoal)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__Usuarios__IdPerf__3E52440B");

                entity.HasOne(d => d.IdProfissaoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdProfissao)
                    .HasConstraintName("FK__Usuarios__IdProf__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
