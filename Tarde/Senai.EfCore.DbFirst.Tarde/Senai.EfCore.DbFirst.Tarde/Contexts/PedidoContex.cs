using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Senai.EfCore.DbFirst.Tarde.Domains;

namespace Senai.EfCore.DbFirst.Tarde.Contexts
{
    public partial class PedidoContex : DbContext
    {
        public PedidoContex()
        {
        }

        public PedidoContex(DbContextOptions<PedidoContex> options)
            : base(options)
        {
        }

        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<PedidosItens> PedidosItens { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=Db_Senai_Pedidos_Tarde_Dev;User ID=sa;Password=sa@132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<PedidosItens>(entity =>
            {
                entity.HasIndex(e => e.IdPedido);

                entity.HasIndex(e => e.IdProduto);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.PedidosItens)
                    .HasForeignKey(d => d.IdPedido);

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.PedidosItens)
                    .HasForeignKey(d => d.IdProduto);
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
