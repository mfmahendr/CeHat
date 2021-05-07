using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cehat
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<TblDetail> TblDetails { get; set; }
        public virtual DbSet<TblGejala> TblGejalas { get; set; }
        public virtual DbSet<TblObat> TblObats { get; set; }
        public virtual DbSet<TblPenyakit> TblPenyakits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<Admin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<TblGejala>()
                .Property(e => e.Gejala)
                .IsUnicode(false);

            modelBuilder.Entity<TblGejala>()
                .HasMany(e => e.TblDetails)
                .WithRequired(e => e.TblGejala)
                .HasForeignKey(e => e.IdGejala)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblObat>()
                .Property(e => e.Nama)
                .IsUnicode(false);

            modelBuilder.Entity<TblObat>()
                .Property(e => e.Dosis)
                .IsUnicode(false);

            modelBuilder.Entity<TblObat>()
                .Property(e => e.EfekSamping)
                .IsUnicode(false);

            modelBuilder.Entity<TblObat>()
                .HasMany(e => e.TblPenyakits)
                .WithRequired(e => e.TblObat)
                .HasForeignKey(e => e.IdObat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TblPenyakit>()
                .Property(e => e.Nama)
                .IsUnicode(false);

            modelBuilder.Entity<TblPenyakit>()
                .HasMany(e => e.TblDetails)
                .WithRequired(e => e.TblPenyakit)
                .HasForeignKey(e => e.IdPenyakit)
                .WillCascadeOnDelete(false);
        }
    }
}
