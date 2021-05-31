namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class AturanGejala
    {
        #region Field
        // Kolom
        [Key]
        public int Id { get; set; }

        public int IdPenyakit { get; set; }

        public int IdGejala { get; set; }

        // Navigation properties
        public virtual Gejala Gejala { get; set; }

        public virtual Penyakit Penyakit { get; set; }

        private CeHatContext dbo = Akses.Tabel();

        #endregion

        public List<ViewAturanGejala> GetAturanGejala()
        {
            return dbo.ViewAturanGejalas.ToList();
        }

        public List<ViewAturanGejala> GetAturanGejala(string kondisi)
        {
            return dbo.ViewAturanGejalas.Where(x => x.DetailGejala.Contains(kondisi)).ToList();
        }

        public string GetNamaPenyakit(int id)
        {
            return dbo.Penyakits.Where(x => x.Id == id).Select(x => x.Nama).SingleOrDefault().ToString();
        }

        public List<string> GetGejala(int id)
        {
            return dbo.Gejalas.Where(x => x.Id == id).Select(x => x.DetailGejala).ToList();
        }

    }
}
