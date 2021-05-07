namespace cehat.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TblPenyakit")]
    public partial class TblPenyakit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPenyakit()
        {
            TblDetails = new HashSet<TblDetail>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nama { get; set; }

        public int? IdObat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblDetail> TblDetails { get; set; }

        public virtual TblObat TblObat { get; set; }
    }
}
