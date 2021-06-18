using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Models
{
    public partial class DB_BNPPContext : DbContext
    {
        public DB_BNPPContext()
        {
        }

        public DB_BNPPContext(DbContextOptions<DB_BNPPContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DB_BNPP;");
            }
        }

        public virtual DbSet<MovimentoManual> MovimentoManual { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoCosif> ProdutoCosif { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovimentoManual>(entity =>
            {
                entity.HasKey(e => new { e.DatMes, e.DatAno, e.NumLancamento, e.CodCosif });

                entity.ToTable("MOVIMENTO_MANUAL");

                entity.Property(e => e.DatMes)
                    .HasColumnName("DAT_MES")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.DatAno)
                    .HasColumnName("DAT_ANO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.NumLancamento)
                    .HasColumnName("NUM_LANCAMENTO")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CodCosif)
                    .HasColumnName("COD_COSIF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.CodProduto)
                    .IsRequired()
                    .HasColumnName("COD_PRODUTO")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.CodUsuarios)
                    .IsRequired()
                    .HasColumnName("COD_USUARIOS")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DatMovimento)
                    .HasColumnName("DAT_MOVIMENTO")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DesDescricao)
                    .IsRequired()
                    .HasColumnName("DES_DESCRICAO")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValValor)
                    .HasColumnName("VAL_VALOR")
                    .HasColumnType("numeric(18, 2)");

                entity.HasOne(d => d.CodCosifNavigation)
                    .WithMany(p => p.MovimentoManual)
                    .HasForeignKey(d => d.CodCosif)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MOVIMENTO__COD_C__3E52440B");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodProduto);

                entity.ToTable("PRODUTO");

                entity.Property(e => e.CodProduto)
                    .HasColumnName("COD_PRODUTO")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DesProduto)
                    .HasColumnName("DES_PRODUTO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.StaStatus)
                    .HasColumnName("STA_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProdutoCosif>(entity =>
            {
                entity.HasKey(e => e.CodCosif);

                entity.ToTable("PRODUTO_COSIF");

                entity.Property(e => e.CodCosif)
                    .HasColumnName("COD_COSIF")
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodClassificacao)
                    .HasColumnName("COD_CLASSIFICACAO")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CodProduto)
                    .IsRequired()
                    .HasColumnName("COD_PRODUTO")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.StaStatus)
                    .HasColumnName("STA_STATUS")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodProdutoNavigation)
                    .WithMany(p => p.ProdutoCosif)
                    .HasForeignKey(d => d.CodProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PRODUTO_C__COD_P__3B75D760");
            });
        }
    }
}
