using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cehat
{
    public partial class CeHatContext : DbContext
    {
        public CeHatContext()
            : base("name=cehat.Properties.Settings.CeHatContext")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<AturanGejala> AturanGejalas { get; set; }
        public virtual DbSet<AturanObat> AturanObats { get; set; }
        public virtual DbSet<Gejala> Gejalas { get; set; }
        public virtual DbSet<HasilDiagnosis> HasilDiagnosis { get; set; }
        public virtual DbSet<Obat> Obats { get; set; }
        public virtual DbSet<Penyakit> Penyakits { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<ViewAturanGejala> ViewAturanGejalas { get; set; }
        public virtual DbSet<ViewAturanObat> ViewAturanObats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gejala>()
                .HasMany(e => e.AturanGejalas)
                .WithRequired(e => e.Gejala)
                .HasForeignKey(e => e.IdGejala)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Obat>()
                .Property(e => e.Nama)
                .IsUnicode(false);

            modelBuilder.Entity<Obat>()
                .Property(e => e.DosisObat)
                .IsUnicode(false);

            modelBuilder.Entity<Obat>()
                .HasMany(e => e.AturanObats)
                .WithOptional(e => e.Obat)
                .HasForeignKey(e => e.IdObat);

            modelBuilder.Entity<Penyakit>()
                .HasMany(e => e.AturanGejalas)
                .WithRequired(e => e.Penyakit)
                .HasForeignKey(e => e.IdPenyakit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Penyakit>()
                .HasMany(e => e.AturanObats)
                .WithRequired(e => e.Penyakit)
                .HasForeignKey(e => e.IdPenyakit)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ViewAturanObat>()
                .Property(e => e.Nama)
                .IsUnicode(false);
        }
    }
}
