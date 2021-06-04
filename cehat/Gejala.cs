namespace cehat
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Gejala")]
    public partial class Gejala
    {
        private bool status;
        private CeHatContext dbo = Akses.Tabel();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Gejala()
        {
            AturanGejalas = new HashSet<AturanGejala>();
        }

        public int Id { get; set; }

        public string DetailGejala { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AturanGejala> AturanGejalas { get; set; }

        public List<Gejala> GetListSemuaDataBerdasarkan(int id)
        {
            return dbo.Gejalas.Where(x => x.Id == id).ToList();
        }

        public List<Gejala> GetListSemuaDataBerdasarkan(string gejala)
        {
            return dbo.Gejalas.Where(x => x.DetailGejala == gejala).ToList();
        }

        public List<string> GetListDetailGejala()
        {
            return dbo.Gejalas.Select(x => x.DetailGejala).ToList();
        }

        public string GetDetailGejala(int id)
        {
            return dbo.Gejalas.Where(x => x.Id == id).Select(x => x.DetailGejala).Single();
        }

        public int GetIdBerdasarkan(string detailGejala)
        {
            return dbo.Gejalas.Where(x => x.DetailGejala == detailGejala).Select(x => x.Id).Single();
        }

        public bool Tambah(string gejala)
        {

            if (!dbo.Gejalas.Any(x => x.DetailGejala == gejala))
            {

                dbo.Gejalas.Add(new Gejala() { DetailGejala = gejala });
                dbo.SaveChanges();
                status = true;
                
            }
            else
            {
                status = false;
            }

            return status;
        }

        /// <summary>
        /// Method yang berfungsi untuk mengubah data DetailGejala 
        /// </summary>
        /// <param name="kondisi"></param>
        /// <param name="detailBaru"></param>
        /// <returns></returns>
        public bool Ubah(string kondisi, string detailBaru)
        {
            if (!dbo.Gejalas.Any(x => x.DetailGejala == detailBaru))
            {
                var gejala = dbo.Gejalas.Where(x => x.DetailGejala == kondisi);
                
                foreach (var x in gejala)
                {
                    x.DetailGejala = detailBaru;
                }
                dbo.SaveChanges();
                status = true;
            }
            else { status = false; }

            return status;
        }

        /// <summary>
        /// Method untuk mengubah Id gejala
        /// </summary>
        /// <param name="kondisi"></param>
        /// <param name="detailBaru"></param>
        /// <returns></returns>
        public bool Ubah(int kondisi, string detailBaru)
        {
            if (!dbo.Gejalas.Any(x => x.DetailGejala == detailBaru))
            {
                var gejala = dbo.Gejalas.Where(x => x.Id == kondisi);
                foreach (var x in gejala)
                {
                    x.DetailGejala = detailBaru;
                }
                status = true;
            }
            else { status = false; ; }

            dbo.SaveChanges();
            return status;
        }

        /// <summary>
        /// Method untuk menghapus data Gejala berdasarkan id atau detail gejalanya 
        /// bergantung pada apakah hanya id atau detail gejalanya saja yang diubah 
        /// ataukah keduanya yang akan diubah
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gejala"></param>
        /// <returns></returns>
        public bool Hapus(int id = 0, string gejala = "")
        {
            if (id != 0 && gejala != "" )
            {
                dbo.Gejalas.RemoveRange(dbo.Gejalas.Where(x => x.Id == id && x.DetailGejala == gejala));

                status = true;
            }
            else if (id != 0)
            {
                dbo.Gejalas.RemoveRange(dbo.Gejalas.Where(x => x.Id == id));

                status = true;
            }
            else if (gejala != "")
            {
                dbo.Gejalas.RemoveRange(dbo.Gejalas.Where(x => x.DetailGejala == gejala));

                status = true;
            }
            else { status = false; }

            dbo.SaveChanges();
            return status;
        }
        
    }
}

