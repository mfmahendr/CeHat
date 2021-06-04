namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("AturanGejala")]
    public partial class AturanGejala
    {
        #region Field
        private CeHatContext dbo = Akses.Tabel();
        private bool status;

        // Kolom
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdPenyakit")]
        public int IdPenyakit { get; set; }

        [Column("IdGejala")]
        public int IdGejala { get; set; }

        // Navigation properties
        public virtual Gejala Gejala { get; set; }
        public virtual Penyakit Penyakit { get; set; }


        #endregion

        public List<ViewAturanGejala> GetAturanGejala()
        {
            return dbo.ViewAturanGejalas.ToList();
        }

        public List<ViewAturanGejala> GetAturanGejala(string kondisi)
        {
            return dbo.ViewAturanGejalas.Where(x => x.DetailGejala.Contains(kondisi)).ToList();
        }

        //public string GetPenyakitBerdasarkan(List<string> kumpulanGejala)
        //{
        //    foreach(string gejala in kumpulanGejala)
        //    {

        //    }
        //}

        public List<int> GetIdGejalaBerdasarkan(int idPenyakit)
        {
            return dbo.AturanGejalas.Where(x => x.IdPenyakit == idPenyakit).Select(x => x.IdGejala).ToList();
        }

        public List< IGrouping<int, AturanGejala> > GetIdPenyakitBerdasarkan(int jumlahGejala)
        {
            return dbo.AturanGejalas.GroupBy(x => x.IdPenyakit).Where(y => y.Count() == jumlahGejala).ToList();
        }

        public bool Tambah(string namaPenyakit, string detailGejala)
        {
            status = false;
            int idPenyakit = dbo.Penyakits.Where(x => x.Nama == namaPenyakit).Select(x => x.Id).Single();
            int idGejala = dbo.Gejalas.Where(x => x.DetailGejala == detailGejala).Select(x => x.Id).Single();
            
            if (idPenyakit != 0 && idGejala != 0)
            {
                status = Tambah(idPenyakit, idGejala);
            }

            dbo.SaveChanges();
            return status;
        }

        public bool Tambah(int idPenyakit, int idGejala)
        {
            status = false;
            if (!dbo.AturanGejalas.Any(x => x.IdPenyakit == idPenyakit && x.IdGejala == idGejala))
            {
                dbo.AturanGejalas.Add(new AturanGejala()
                {
                    IdPenyakit = idPenyakit,
                    IdGejala = idGejala
                });
                dbo.SaveChanges();
                status = true;
            }
            return status;
        }

        public bool Hapus(int idPenyakit, int idGejala)
        {
            dbo.AturanGejalas.Remove(dbo.AturanGejalas
                .Where(x => x.IdPenyakit == idPenyakit && x.IdGejala == idGejala).Single());

            dbo.SaveChanges();
            return true;
        }

    }
}
