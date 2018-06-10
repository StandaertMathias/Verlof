using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Verlof.Data
{
    public partial class AanvragenContext : DbContext
    {
        public virtual DbSet<Aanvragen> Aanvragen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=aspnet-Verlof-E8C0492F-DBD2-44D4-BB22-4092B68FAA1C;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True; ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aanvragen>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.MotivatieAanvraag).HasColumnName("motivatieAanvraag");

                entity.Property(e => e.MotivatieManager).HasColumnName("motivatieManager");

                entity.Property(e => e.NaamAanvrager)
                    .IsRequired()
                    .HasColumnName("naamAanvrager")
                    .HasMaxLength(50);

                entity.Property(e => e.NaamManager)
                    .HasColumnName("naamManager")
                    .HasMaxLength(50);

                entity.Property(e => e.StatusAanvraag)
                    .IsRequired()
                    .HasColumnName("statusAanvraag")
                    .HasMaxLength(20);
            });
        }
    }
}
