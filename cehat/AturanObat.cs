namespace cehat
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AturanObat")]
    public partial class AturanObat
    {
        #region Field
        private bool status;
        private CeHatContext dbo = Akses.Tabel();

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[Column("IdPenyakit")]
        //public int IdPenyakit { get; set; }


        //[Column("IdObat")]
        //public int? IdObat { get; set; }

        //// Navigation properties
        //public virtual Penyakit Penyakit { get; set; }
        //public virtual Obat Obat { get; set; }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdPenyakit")]
        public int IdPenyakit { get; set; }

        [Column("IdObat")]
        public int? IdObat { get; set; }

        // Navigation Properties
        public virtual Obat Obat { get; set; }
        public virtual Penyakit Penyakit { get; set; }

        #endregion

        public List<ViewAturanObat> GetAturanObat()
        {
            return dbo.ViewAturanObats.Select(x => x).ToList();
        }

        public List<ViewAturanObat> GetAturanObat(string kondisi)
        {
            return dbo.ViewAturanObats.Where(x => x.Nama.Contains(kondisi)).ToList();
        }

        public string GetNamaObat(int? id)
        {
            if (id != null)
            {
                return Obat.GetNama((int)id);
            }
            else { return null; }
        }

        public int GetIdPenyakit(string namaPenyakit)
        {
            return dbo.Penyakits.Where(x => x.Nama == namaPenyakit).Select(x => x.Id).SingleOrDefault();
        }

        public int GetIdObat(string namaObat)
        {
            return dbo.Obats.Where(x => x.Nama == namaObat).Select(x => x.Id).SingleOrDefault();
        }

        public bool Tambah(string namaPenyakit, string namaObat = "")
        {
            status = false;
            int? idObat = null;
            int idPenyakit = dbo.Penyakits.Where(x => x.Nama == namaPenyakit).Select(x => x.Id).Single();

            if (namaObat != "")
            {
                idObat = dbo.Obats.Where(x => x.Nama == namaObat).Select(x => x.Id).Single();
            }

            if (idPenyakit != 0 && idObat != null)
            {
                if (!dbo.AturanObats.Any(x => x.IdPenyakit == idPenyakit && x.IdObat == idObat))
                {
                    dbo.AturanObats.Add(new AturanObat()
                    {
                        IdPenyakit = idPenyakit,
                        IdObat = idObat
                    });

                    status = true;
                }
            }
            else if (idPenyakit != 0)
            {
                if (!dbo.AturanObats.Any(x => x.IdPenyakit == idPenyakit))
                {
                    dbo.AturanObats.Add(new AturanObat()
                    { 
                        IdPenyakit = idPenyakit, 
                        IdObat = null 
                    });

                    status = true;
                }
            }

            dbo.SaveChanges();
            return status;
        }

        public bool Tambah(int idPenyakit, int? idObat)
        {
            status = false;
            if (!dbo.AturanObats.Any(x => x.IdPenyakit == idPenyakit && x.IdObat == idObat))
            {
                dbo.AturanObats.Add(new AturanObat()
                {
                    IdPenyakit = idPenyakit,
                    IdObat = idObat
                });
                dbo.SaveChanges();
                status = true;
            }

            System.Windows.Forms.MessageBox.Show(dbo.AturanObats.Where(x => x.IdPenyakit == idPenyakit && x.IdObat == idObat).Select(y => y.IdPenyakit).ToString());

            return status;
        }

        public bool Hapus(int idPenyakit, int? idObat)
        {
            dbo.AturanObats.Remove(dbo.AturanObats
                .Where(x => x.IdPenyakit == idPenyakit && x.IdObat == idObat).Single());

            dbo.SaveChanges();
            return true;
        }
    }
}