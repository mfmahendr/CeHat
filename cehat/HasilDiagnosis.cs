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
        CeHatContext dbo = Akses.Tabel();

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NamaPenyakit { get; set; }

        [Required]
        public int Frekuensi { get; set; }

        public void Tambah(string namaPenyakit)
        {
            
        }

        public void UbahFrekuensi(int id, int frekuensi)
        {
            var hasil = dbo.HasilDiagnosis.Where(x => x.Id == id).ToList();
            foreach(var x in hasil)
            {
                x.Frekuensi = frekuensi + 1;
            }
            dbo.SaveChanges();
        }
    }
}
