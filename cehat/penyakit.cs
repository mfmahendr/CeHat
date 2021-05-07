namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblPenyakit")]
    public partial class TblPenyakit : Informasi // sebagai class penyakit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblDetail> TblDetails { get; set; }  // sebagai kumpulan gejala

        public virtual TblObat TblObat { get; set; }   // Atributnya sebagai obat


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPenyakit()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        [Required]
        [StringLength(50)]

        public int IdObat { get; set; }

        public void ShowInfo()
        {
            throw new NotImplementedException();
        }

        public bool CekInfo(TblPenyakit penyakit)
        {
            throw new NotImplementedException();
        }
    }
}
