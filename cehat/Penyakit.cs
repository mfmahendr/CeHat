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
        private HasilDiagnosis hasilDiagnosis = new HasilDiagnosis();

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


        public static Penyakit GetDataBerdasarkan(int id)
        {
            return dbo.Penyakits.Where(x => x.Id == id).Single();
        }

        public static List<Penyakit> GetDataBerdasarkan(string namaPenyakit)
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

                hasilDiagnosis.Tambah(namaPenyakit);
                
                dbo.SaveChanges();
                status = true;
            }
            else
            {
                status = false;
            }

            return status;
        }

        public bool Ubah(string kondisiNama, string namaBaru, string detailBaru)
        {
            status = false;

            if (!dbo.Penyakits.Any(x => x.Nama == namaBaru))
            {
                var penyakits = GetDataBerdasarkan(kondisiNama);

                foreach (var x in penyakits)
                {
                    x.Nama = namaBaru;
                    x.DetailPenyakit = detailBaru;
                }

                hasilDiagnosis.UbahNamaPenyakit(kondisiNama, namaBaru);

                dbo.SaveChanges();
                status = true;
            }

            return status;
        }

        public bool Ubah(int kondisiId, string namaBaru = "", string detailBaru = "")
        {
            status = false;

            if (namaBaru != "" && detailBaru != "")
            {
                if (!dbo.Penyakits.Any(x => x.Nama == namaBaru) && !dbo.Penyakits.Any(x => x.DetailPenyakit == detailBaru))
                {
                    var penyakits = GetDataBerdasarkan(kondisiId);

                    penyakits.Nama = namaBaru;
                    penyakits.DetailPenyakit = detailBaru;

                    hasilDiagnosis.UbahNamaPenyakit(kondisiId, namaBaru);

                    status = true;
                }
            }
            else if (namaBaru != "")
            {
                if (!dbo.Penyakits.Any(x => x.Nama == namaBaru))
                {
                    var penyakit = GetDataBerdasarkan(kondisiId);
                    penyakit.Nama = namaBaru;

                    hasilDiagnosis.UbahNamaPenyakit(kondisiId, namaBaru);

                    status = true;
                }
            }
            else if(detailBaru != "")
            {
                if (!dbo.Penyakits.Any(x => x.DetailPenyakit == detailBaru))
                {
                    var penyakit = GetDataBerdasarkan(kondisiId);
                    penyakit.DetailPenyakit = detailBaru;

                    hasilDiagnosis.UbahNamaPenyakit(kondisiId, namaBaru);

                    status = true;
                }
            }
            dbo.SaveChanges();
            return status;
        }

        public bool Hapus(int id = 0, string namaPenyakit = "")
        {
            status = false;

            if (id != 0 && namaPenyakit != "")
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits
                .Where(x => x.Id == id && x.Nama == namaPenyakit));

                hasilDiagnosis.HapusPenyakit(id, namaPenyakit);

                status = true;
            }
            else if (id != 0)
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits.Where(x => x.Id == id));

                hasilDiagnosis.HapusPenyakit(id);

                status = true;
            }
            else if (namaPenyakit != "")
            {
                dbo.Penyakits.RemoveRange(dbo.Penyakits
                .Where(x => x.Nama == namaPenyakit));

                hasilDiagnosis.HapusPenyakit(namaPenyakit);

                status = true;
            }
            

            dbo.SaveChanges();
            return status;
        }

    }
}
