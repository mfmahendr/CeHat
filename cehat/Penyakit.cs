namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Penyakit")]
    public partial class Penyakit : Informasi
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Penyakit()
        {
            AturanGejalas = new HashSet<AturanGejala>();
            AturanObats = new HashSet<AturanObat>();
        }

        public string DetailPenyakit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AturanGejala> AturanGejalas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AturanObat> AturanObats { get; set; }


        public static List<Penyakit> GetListSemuaDataBerdasarkan(int id)
        {
            return dbo.Penyakits.Where(x => x.Id == id).ToList();
        }

        public static List<Penyakit> GetListSemuaDataBerdasarkan(string namaPenyakit)
        {
            return dbo.Penyakits.Where(x => x.Nama == namaPenyakit).ToList();
        }

        public static List<string> GetListNamaPenyakit()
        {
            return dbo.Penyakits.Select(x => x.Nama).ToList();
        }

        public static string GetNamaBerdasarkan(int id)
        {
            return dbo.Penyakits.Where(x => x.Id == id).Select(x => x.Nama).Single();
        }

        public static int GetIdBerdasarkan(string namaPenyakit)
        {
            return dbo.Penyakits.Where(x => x.Nama == namaPenyakit).Select(x => x.Id).Single();
        }

        public bool Tambah(string namaPenyakit, string detail)
        {

            if (!dbo.Penyakits.Any(x => x.Nama == namaPenyakit))
            {
                dbo.Penyakits.Add(new Penyakit() { Nama = namaPenyakit, DetailPenyakit = detail });
                dbo.SaveChanges();
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        public bool Ubah(string kondisiNama, string penyakit, string detailBaru)
        {
            if (!dbo.Penyakits.Any(x => x.Nama == penyakit))
            {
                var penyakits = dbo.Penyakits.Where(x => x.Nama == kondisiNama);

                foreach (var x in penyakits)
                {
                    x.Nama = penyakit;
                    x.DetailPenyakit = detailBaru;
                }
                dbo.SaveChanges();
                status = true;
            }
            else { status = false; }

            return status;
        }

        public bool Ubah(int kondisiId, string penyakit = "", string detailBaru = "")
        {
            if (penyakit != "" && detailBaru != "")
            {
                if (!dbo.Penyakits.Any(x => x.Nama == penyakit) && !dbo.Penyakits.Any(x => x.DetailPenyakit == detailBaru))
                {
                    var penyakits = dbo.Penyakits.Where(x => x.Id == kondisiId);

                    foreach (var x in penyakits)
                    {
                        x.Nama = penyakit;
                        x.DetailPenyakit = detailBaru;
                    }
                    dbo.SaveChanges();
                    status = true;
                }
                else { status = false; }
            }
            else if (penyakit != "")
            {
                if (!dbo.Penyakits.Any(x => x.Nama == penyakit))
                {
                    var penyakits = dbo.Penyakits.Where(x => x.Id == kondisiId);

                    foreach (var x in penyakits)
                    {
                        x.Nama = penyakit;
                    }
                    dbo.SaveChanges();
                    status = true;
                }
                else { status = false; }
            }
            else if(detailBaru != "")
            {
                if (!dbo.Penyakits.Any(x => x.DetailPenyakit == detailBaru))
                {
                    var penyakits = dbo.Penyakits.Where(x => x.Id == kondisiId);

                    foreach (var x in penyakits)
                    {
                        x.DetailPenyakit = detailBaru;
                    }
                    dbo.SaveChanges();
                    status = true;
                }
                else { status = false; }
            }

            return status;
        }

        public bool Hapus(int id = 0, string namaPenyakit = "", string detailPenyakit = "")
        {
            if (id != 0 && namaPenyakit != "" && detailPenyakit != "")
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits
                .Where(x => x.Id == id && x.Nama == namaPenyakit && x.DetailPenyakit == detailPenyakit));
                status = true;
            }
            else if (namaPenyakit != "" && detailPenyakit != "")
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits
                .Where(x => x.Nama == namaPenyakit && x.DetailPenyakit == detailPenyakit));

                status = true;
            }
            else if (id != 0)
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits.Where(x => x.Id == id));                
                status = true;
            }
            else if (namaPenyakit != "")
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits.Where(x => x.Nama == namaPenyakit));
                status = true;
            }
            else if (detailPenyakit != "")
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits.Where(x => x.DetailPenyakit == detailPenyakit));
                status = true;
            }
            else { status = false; }

            dbo.SaveChanges();
            return status;
        }

    }
}
