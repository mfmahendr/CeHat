namespace cehat
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblObat")]
    public partial class TblObat : Informasi // sebagai class Obat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblObat()
        {
            TblPenyakits = new HashSet<TblPenyakit>();
        }

        [Required]
        [StringLength(50)]
        public new string Nama { get; set; }

        [Column(TypeName = "text")]
        public string Dosis { get; set; }

        [Column(TypeName = "text")]
        public string EfekSamping { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPenyakit> TblPenyakits { get; set; }
    }
}
