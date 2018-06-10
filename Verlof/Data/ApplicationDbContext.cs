using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Verlof.Models;

namespace Verlof.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Aanvragen>(entity =>
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
