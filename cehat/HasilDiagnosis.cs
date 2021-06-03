namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("HasilDiagnosis")]
    public partial class HasilDiagnosis
    {
        private CeHatContext dbo = Akses.Tabel();

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaPenyakit { get; set; }

        [Required]
        public int Frekuensi { get; set; }

        public void Tambah(string namaPenyakit)
        {
            dbo.HasilDiagnosis.Add(new HasilDiagnosis() { NamaPenyakit = namaPenyakit, Frekuensi = 0 });
        }

        public void UbahNamaPenyakit(string namaLama , string namaBaru)
        {
            var hasilDiagnosis = dbo.HasilDiagnosis.Where(x => x.NamaPenyakit == namaLama).Single();
            hasilDiagnosis.NamaPenyakit = namaBaru;
            dbo.SaveChanges();
        }

        public void UbahNamaPenyakit(int kondisiId, string namaBaru)
        {
            var hasilDiagnosis = dbo.HasilDiagnosis.Where(x => x.Id == kondisiId).Single();
            hasilDiagnosis.NamaPenyakit = namaBaru;
            dbo.SaveChanges();
        }

        public void UbahFrekuensi(int id)
        {
            var hasil = dbo.HasilDiagnosis.Where(x => x.Id == id).Single();

            hasil.Frekuensi++;

            dbo.SaveChanges();
        }

        public void UbahFrekuensi(string namaPenyakit)
        {
            var hasil = dbo.HasilDiagnosis.Where(x => x.NamaPenyakit == namaPenyakit).Single();
            
            hasil.Frekuensi++;
            
            dbo.SaveChanges();
        }

        public void HapusPenyakit(int id)
        {
            dbo.HasilDiagnosis.Remove(dbo.HasilDiagnosis.Where(x => x.Id == id).Single());
            dbo.SaveChanges();
        }

        public void HapusPenyakit(string namaPenyakit)
        {
            dbo.HasilDiagnosis.Remove(dbo.HasilDiagnosis.Where(x => x.NamaPenyakit == namaPenyakit).Single());
            dbo.SaveChanges();
        }

        public void HapusPenyakit(int id, string namaPenyakit)
        {
            dbo.HasilDiagnosis.Remove(dbo.HasilDiagnosis.Where(x => x.Id == id && x.NamaPenyakit == namaPenyakit).Single());
            dbo.SaveChanges();
        }
    }
}