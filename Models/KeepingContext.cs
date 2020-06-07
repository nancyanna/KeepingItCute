using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KeepingItCute.Models;

namespace KeepingItCute.Models
{
    public partial class KeepingContext : DbContext
    {
        public KeepingContext()
        {
        }

        public KeepingContext(DbContextOptions<KeepingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Keeping;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Style)
                    .IsRequired()
                    .HasColumnName("style")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StyleId).HasColumnName("styleID");
            });
        }

        public DbSet<KeepingItCute.Models.Customer> Customer { get; set; }

        public DbSet<KeepingItCute.Models.Style> Style { get; set; }
    }
}
