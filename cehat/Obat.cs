namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Obat")]
    public partial class Obat : Informasi
    {
        #region Atribut
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Obat()
        {
            AturanObats = new HashSet<AturanObat>();
        }

        public string DosisObat { get; set; }

        public string EfekObat { get; set; }

        // Navigation properties
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AturanObat> AturanObats { get; set; }
        #endregion

        #region Method
        #region Read
        public List<Obat> GetDataBerdasarkan(int id)
        {
            return dbo.Obats.Where(x => x.Id == id).ToList();
        }

        public List<Obat> GetDataBerdasarkan(string namaObat)
        {
            return dbo.Obats.Where(x => x.Nama == namaObat).ToList();
        }

        public List<string> GetListNamaObat()
        {
            return dbo.Obats.Select(x => x.Nama).ToList();
        }

        public int GetIdBerdasarkan(string namaObat)
        {
            return dbo.Obats.Where(x => x.Nama == namaObat).Select(x => x.Id).Single();
        }

        public string GetDosisBerdasarkan(int idObat)
        {
            string dosis;
            try
            {
                dosis = dbo.Obats.Where(x => x.Id == idObat).Select(x => x.DosisObat).Single();
            }
            catch (InvalidOperationException)
            {
                dosis = "";
            }

            return dosis;
        }

        public string GetEfekSampingBerdasarkan(int idObat)
        {
            string efekSamping;
            try
            {
                efekSamping = dbo.Obats.Where(x => x.Id == idObat).Select(x => x.EfekObat).Single();
            }
            catch (InvalidOperationException)
            {
                efekSamping = "";
            }

            return efekSamping;
        }

        public string GetNamaBerdasarkan(int id)
        {
            return dbo.Obats.Where(x => x.Id == id).Select(x => x.Nama).Single();
        }
        #endregion

        public bool Tambah(string namaObat, string dosis = "", string efek = "")
        {
            status = true;

            if (dosis != "" && efek != "")
            {

                if (!dbo.Obats.Any(x => x.Nama == namaObat) && 
                    !dbo.Obats.Any(x => x.DosisObat == dosis) && 
                    !dbo.Obats.Any(x => x.EfekObat == efek))
                {
                    dbo.Obats.Add(new Obat() 
                    { 
                        Nama = namaObat, 
                        DosisObat = dosis, 
                        EfekObat = efek 
                    });
                    dbo.SaveChanges();

                    status = true;
                }
            }
            else if (dosis != "")
            {

                if (!dbo.Obats.Any(x => x.Nama == namaObat) && !dbo.Obats.Any(x => x.DosisObat == dosis))
                {
                    dbo.Obats.Add(new Obat()
                    {
                        Nama = namaObat,
                        DosisObat = dosis,
                    });
                    dbo.SaveChanges();
                    status = true;
                }
            }
            else if (efek != "")
            {

                if (!dbo.Obats.Any(x => x.Nama == namaObat) && !dbo.Obats.Any(x => x.EfekObat == efek))
                {
                    dbo.Obats.Add(new Obat()
                    {
                        Nama = namaObat,
                        EfekObat = efek,
                });
                    dbo.SaveChanges();
                    status = true;
                }
            }
            else
            {
                if (!dbo.Obats.Any(x => x.Nama == namaObat))
                {
                    dbo.Obats.Add(new Obat(){ Nama = namaObat });
                    dbo.SaveChanges();
                    status = true;
                }
            }
            return status;
        }

        public bool Ubah(int kondisi, string namaObat = "", string dosis = "", string efek = "")
        {
            if (namaObat != "" && dosis != "" && efek != "")
            {
                if (!dbo.Obats.Any(x => x.Nama == namaObat) && 
                    !dbo.Obats.Any(x => x.DosisObat == dosis) &&
                    !dbo.Obats.Any(x => x.EfekObat == dosis))
                {
                    var obats = dbo.Obats.Where(x => x.Id == kondisi);
                    foreach (var obat in obats)
                    {
                        obat.Nama = namaObat;
                        obat.DosisObat = dosis;
                        obat.EfekObat = efek;
                    }

                    status = true;
                }
                else { status = false; }
            }
            else if (namaObat != "" && dosis != "")
            {
                if (!dbo.Obats.Any(x => x.Nama == namaObat) && !dbo.Obats.Any(x => x.DosisObat == dosis))
                {
                    var obats = dbo.Obats.Where(x => x.Id == kondisi);
                    foreach (var obat in obats)
                    {
                        obat.Nama = namaObat;
                        obat.DosisObat = dosis;
                    }

                    status = true;
                }
                else { status = false; }
            }
            else if (namaObat != "" && efek != "")
            {
                if (!dbo.Obats.Any(x => x.Nama == namaObat) && !dbo.Obats.Any(x => x.EfekObat == efek))
                {
                    var obats = dbo.Obats.Where(x => x.Id == kondisi);
                    foreach (var obat in obats)
                    {
                        obat.Nama = namaObat;
                        obat.EfekObat = efek;
                    }

                    status = true;
                }
                else { status = false; }
            }
            else if (dosis != "" && efek != "")
            {
                if (!dbo.Obats.Any(x => x.EfekObat == efek) && !dbo.Obats.Any(x => x.DosisObat == dosis))
                {
                    var obats = dbo.Obats.Where(x => x.Id == kondisi);
                    foreach (var obat in obats)
                    {
                        obat.EfekObat = efek;
                        obat.DosisObat = dosis;
                    }
                    

                    status = true;
                }
                else { status = false; }
            }
            else if (namaObat != "")
            {
                if (!dbo.Obats.Any(x => x.Nama == namaObat))
                {
                    var obats = dbo.Obats.Where(x => x.Id == kondisi);
                    foreach (var obat in obats)
                    {
                        obat.Nama = namaObat;
                    }
                    status = true;
                }
                else { status = false; }
            }
            else if (dosis != "")
            {
                if (!dbo.Obats.Any(x => x.DosisObat == dosis))
                {
                    var obats = dbo.Obats.Where(x => x.Id == kondisi);
                    
                    foreach (var obat in obats)
                    {
                        obat.DosisObat = dosis;
                    }
                    status = true;
                }
                else { status = false; }
            }
            else if (efek != "")
            {
                if (!dbo.Obats.Any(x => x.EfekObat == efek))
                {
                    var obats = dbo.Obats.Where(x => x.Id == kondisi);

                    foreach (var obat in obats)
                    {
                        obat.EfekObat = efek;
                    }
                    status = true;
                }
                else { status = false; }
            }

            dbo.SaveChanges();
            return status;
        }

        public bool Hapus(int id = 0, string namaObat = "", string dosis = "", string efek = "")
        {
            if (id != 0 && namaObat != "" && efek != "" && dosis != "")
            {
                dbo.Obats.RemoveRange(dbo.Obats
                .Where(x => x.Id == id && x.Nama == namaObat && x.DosisObat == dosis && x.EfekObat == efek));

                status = true;
            }
            else if (id != 0 && namaObat != "" && dosis != "")
            {
                dbo.Obats.RemoveRange(dbo.Obats
                .Where(x => x.Id == id && x.Nama == namaObat && x.DosisObat == dosis));

                status = true;
            }
            else if (id != 0 && namaObat != "" && efek != "")
            {
                dbo.Obats.RemoveRange(dbo.Obats
                .Where(x => x.Id == id && x.Nama == namaObat &&  x.EfekObat == efek));

                status = true;
            }
            else if (id != 0 && namaObat != "")
            {
                dbo.Obats.RemoveRange(dbo.Obats.Where(x => x.Id == id && x.Nama == namaObat));

                status = true;
            }
            else if (id != 0)
            {
                dbo.Obats.RemoveRange(dbo.Obats.Where(x => x.Id == id));

                status = true;
            }
            else if (namaObat != "")
            {
                dbo.Obats.RemoveRange(dbo.Obats.Where(x => x.Nama == namaObat));

                status = true;
            }
            else if (dosis != "")
            {
                dbo.Obats.RemoveRange(dbo.Obats.Where(x => x.Nama == dosis));

                status = true;
            }
            else if (efek != "")
            {
                dbo.Obats.RemoveRange(dbo.Obats.Where(x => x.EfekObat == efek));

                status = true;
            }
            else { status = false; }

            dbo.SaveChanges();
            return status;
        }
        #endregion
    }
}